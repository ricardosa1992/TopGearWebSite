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
            viewModel.localRetirada = TopGear.Api.TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalRetirada}");
            viewModel.localEntrega = viewModel.localRetirada;

            //Buscando o carro selecionado
            Carro carroSelecionado = TopGear.Api.TopGearApiDataAccess<Carro>.Get($"carro/porid/{idCarroSelecionado}");
            Categoria categoria = TopGear.Api.TopGearApiDataAccess<Categoria>.Get($"categoria/porid/{carroSelecionado.CategoriaId}");
            viewModel.carroSelecionado = new CarroViewModel
            {
                Id = carroSelecionado.Id,
                Marca = carroSelecionado.Marca,
                Modelo = carroSelecionado.Modelo,
                Ano = carroSelecionado.Ano,
                Placa = carroSelecionado.Placa,
                AgenciaId = carroSelecionado.AgenciaId,
                categoria = categoria
            };
            
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