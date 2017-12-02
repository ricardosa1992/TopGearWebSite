using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TopGear.Api.DataAccess;
using TopGear.Api.DataApi;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class LocacaoController : BaseController
    {
        // GET: FinalizarReserva
        public ActionResult CompraPassagens(int idCarroSelecionado, int idLocalRetirada, int idLocalEntrega, string dataRetirada, string dataEntrega,int qtdDiarias, string precoDiaria, string precoTotal)
        {
            BuscarDadosClienteLogado();
            LocacaoViewModel viewModel = new LocacaoViewModel();

           //Obtendo os dados do carro selecionado e do local de retirada / entrega
            viewModel.dataRetirada = Convert.ToDateTime(dataRetirada);
            DateTime dtEntrega = Convert.ToDateTime(dataEntrega);
            viewModel.QtdDiarias = qtdDiarias;
            viewModel.precoDiaria = Convert.ToDouble(precoDiaria);
            viewModel.precoTotal = Convert.ToDouble(precoTotal);

            //Obtendo a Agencia de retirada/Entrega
            viewModel.localRetirada = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalRetirada}");
            //viewModel.localEntrega = (idLocalRetirada == idLocalEntrega || idLocalEntrega == 0) ? viewModel.localRetirada : TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalEntrega}");
            Agencia localEntrega = (idLocalRetirada == idLocalEntrega || idLocalEntrega == 0) ? viewModel.localRetirada : TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalEntrega}");

            //Buscando todos os Vôos
            List<Voo> listaTodosVoos = PassagemApi.GetTodosVoos();

            //Filtrando por localização e data de saída do vôo
           
            foreach (var voo in listaTodosVoos)
            {
                if(voo.cidade_partida.ToLower().Equals(localEntrega.Cidade.ToLower()) && (voo.partida.Date > dtEntrega.Date))
                {
                    viewModel.listaVoos.Add(voo);

                }

            }

            return View(viewModel);

           
        }

        public JsonResult Efetuarlocacao(int idCarro, int idLocalRetirada, int idLocalEntrega, string dataRetirada, string dataEntrega, double precoTotal)
        {

            var idCliente = (int)Sessao.IdUsuarioLogado;
            Locacao novaLocacao = new Locacao()
            {
                ClienteId = idCliente,
                CarroId = idCarro,
                Agencia_RetiradaId = idLocalRetirada,
                Agencia_EntregaId = idLocalEntrega,
                Retirada = Convert.ToDateTime(dataRetirada),
                Entrega = Convert.ToDateTime(dataEntrega),
                Finalizada = false
            };

            var idNovaLocacao = TopGearApiDataAccess<Locacao>.Post(novaLocacao, "locacao");
            return (idNovaLocacao != 0) ? Json(new { Status = "ok" }) : Json(new { Status = "Nok" });

        }

        public ActionResult LocacoesCliente()
        {
            Cliente cliente = BuscarDadosClienteLogado();
            LocacaoClienteViewModel viewModel = new LocacaoClienteViewModel();
            List<Locacao> locacoes = LocacaoApiDataAccess.ObterLocacoes(cliente.Id);
            foreach (var loc in locacoes)
            {
                Carro car = TopGearApiDataAccess<Carro>.Get($"carro/porid/{loc.CarroId}");
                Categoria cat = TopGearApiDataAccess<Categoria>.Get($"categoria/porid/{car.CategoriaId}");

                int qtdDiarias = CalcularQuantidadeDiarias(loc.Retirada, loc.Entrega);

                viewModel.listaLocacoes.Add(new LocacaoViewModel
                {
                    idLocacao = loc.Id,
                    localRetirada = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{loc.Agencia_RetiradaId}"),
                    localEntrega = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{loc.Agencia_EntregaId}"),
                    carroSelecionado = new CarroViewModel {
                        Id = car.Id,
                        Modelo = car.Modelo,
                        Placa = car.Placa,
                        Marca = car.Marca,
                        UrlImagem = car.UrlImagem
                    },
                    dataRetirada = loc.Retirada,
                    dataEntrega = loc.Entrega,
                    precoDiaria = cat.Preco,
                    QtdDiarias = qtdDiarias,
                    precoTotal = cat.Preco * qtdDiarias,
                    finalizada = loc.Finalizada,
                    cancelada = loc.Cancelada
                    
            });
            }

            return View(viewModel);
            
        }

        //Cancela uma locação do cliente 
        public ActionResult CancelarLocacao(int idLocacao)
        {
            bool cancelada = LocacaoApiDataAccess.CancelarLocacao(idLocacao);

            return RedirectToAction("LocacoesCliente", "Locacao");
        }

        public JsonResult ComprarPassagem(int idVoo, int numAcento)
        {
            Cliente cliente = BuscarDadosClienteLogado();

            //PassagemApi.PostCliente(cliente.Nome, "3232", cliente.Nascimento);
            
            int idCompra = PassagemApi.InserirCompra("3232", "32132132132");
            int idTicket = -1;
            if (idCompra != -1)
            {
                idTicket = PassagemApi.InserirTicket(idCompra, idVoo, cliente.Nome, "3232", "32132132132", cliente.Nascimento, numAcento);
            }
            return (idTicket != -1) ? Json(new { Status = "ok" }) : Json(new { Status = "Nok" });

        }

    }
}