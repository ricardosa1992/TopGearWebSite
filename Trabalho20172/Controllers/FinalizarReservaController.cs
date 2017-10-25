using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.DataAccess;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class FinalizarReservaController : BaseController
    {
        // GET: FinalizarReserva
        public ActionResult DadosCliente(int idCarroSelecionado, int idLocalRetirada, int idLocalEntrega, string dataRetirada, string dataEntrega,int qtdDiarias, string precoDiaria, string precoTotal)
        {
            LocacaoViewModel viewModel = new LocacaoViewModel();
           
            //Obtendo os dados do carro selecionado e do local de retirada/entrega
            viewModel.dataRetirada = Convert.ToDateTime(dataRetirada);
            viewModel.dataEntrega = Convert.ToDateTime(dataEntrega);
            viewModel.QtdDiarias = qtdDiarias;
            viewModel.precoDiaria = Convert.ToDouble(precoDiaria);
            viewModel.precoTotal = Convert.ToDouble(precoTotal);

            //Obtendo a Agencia de retirada/Entrega
            viewModel.localRetirada = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalRetirada}");
            viewModel.localEntrega = (idLocalRetirada == idLocalEntrega || idLocalEntrega == 0) ? viewModel.localRetirada : TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalEntrega}");


            //Buscando o carro selecionado
            Carro carroSelecionado = TopGearApiDataAccess<Carro>.Get($"carro/porid/{idCarroSelecionado}");
            Categoria categoria = TopGearApiDataAccess<Categoria>.Get($"categoria/porid/{carroSelecionado.CategoriaId}");
            viewModel.carroSelecionado = new CarroViewModel
            {
                Id = carroSelecionado.Id,
                Marca = carroSelecionado.Marca,
                Modelo = carroSelecionado.Modelo,
                Ano = carroSelecionado.Ano,
                Placa = carroSelecionado.Placa,
                AgenciaId = carroSelecionado.AgenciaId,
                categoria = categoria,
                UrlImagem = carroSelecionado.UrlImagem
            };

            viewModel.listaVoos = TopGearApiDataAccess<Voo>.GetVoos(); 


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

    }
}