using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class FinalizarReservaController : BaseController
    {
        // GET: FinalizarReserva
        public ActionResult DadosCliente(int idCarroSelecionado, int idLocalRetirada, int idLocalEntrega, string dataRetirada, string dataEntrega, string precoTotal)
        {


            LocacaoViewModel viewModel = new LocacaoViewModel();
            viewModel.ListaDeAgencias = ListaDeAgencias();

            //Obtendo os dados do carro selecionado e do local de retirada/entrega
           
            viewModel.dataRetirada = Convert.ToDateTime(dataRetirada);
            viewModel.dataEntrega = Convert.ToDateTime(dataEntrega);
            viewModel.precoTotal = Convert.ToDouble(precoTotal);

            //Obtendo a Agencia de retirada
            viewModel.localRetirada = new Agencia { Id = 9, Nome = "Aeroporto" };
            viewModel.localEntrega = viewModel.localRetirada;

            

            List<Carro> listaCarrosDisponiveis = new List<Carro>();
            listaCarrosDisponiveis.Add(new Carro { Id = 1, CategoriaId = 2, Modelo = "Honda Civic" });
            listaCarrosDisponiveis.Add(new Carro { Id = 2, CategoriaId = 3, Modelo = "Fusca" });
            listaCarrosDisponiveis.Add(new Carro { Id = 5, CategoriaId = 4, Modelo = "Chevete" });

            foreach (var carro in listaCarrosDisponiveis)
            {
                if(carro.Id == idCarroSelecionado)
                {
                    viewModel.carroSelecionado = carro;
                    break;
                }
            }


            return View(viewModel);

           
        }

        public JsonResult Efetuarlocacao(int idCliente, int idCarro, int idLocalRetirada, int idLocalEntrega, string dataRetirada, string horaRetirada, string dataEntrega, string horaEntrega, double precoTotal)
        {
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

            var sucesso = TopGear.Api.TopGearApiDataAccess<Locacao>.Post(novaLocacao, "locacao");
            return (sucesso != null) ? Json(new { Status = "ok" }) : Json(new { Status = "Nok" });

        }

    }
}