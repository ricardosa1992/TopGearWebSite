﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class VeiculoController : BaseController
    {
        // GET: Veiculo
        [HttpPost]
        public ActionResult Veiculos()
        {
            LocacaoViewModel viewModel = new LocacaoViewModel();

            //Obtendo os parâmetros selecionados para retirada/entrega
            int idLocalRetirada = Convert.ToInt32(Request.Form["listaLocalRetirada"]);
            int idLocalEntrega = Convert.ToInt32(Request.Form["listaLocalEntrega"]);
            var horaRetirada = Request.Form["pick-up-time"];
            var horaEntrega = Request.Form["drop-off-time"];
            
            DateTime dataRetirada = Convert.ToDateTime(Request.Form["pick-up-date"]);
            dataRetirada = DateTime.Parse(dataRetirada.ToShortDateString() + " " + horaRetirada);
            DateTime dataEntrega = Convert.ToDateTime(Request.Form["drop-off-date"]);
            dataEntrega = DateTime.Parse(dataEntrega.ToShortDateString() + " " + horaEntrega);

            viewModel.dataRetirada = dataRetirada;
            viewModel.dataEntrega = dataEntrega;
            viewModel.horaRetirada = horaRetirada;
            viewModel.horaEntrega = horaEntrega;

            //Obtendo a Agencia de retirada
            viewModel.localRetirada = TopGear.Api.TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalRetirada}");
            viewModel.localEntrega = (idLocalRetirada == idLocalEntrega || idLocalEntrega == 0) ? viewModel.localRetirada : TopGear.Api.TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalEntrega}");

            //Obtendo a lista de agencias para a Edição
            viewModel.ListaDeAgencias = ListaDeAgencias();

            //Obtendo a quantidade de Diárias
            TimeSpan nod = (dataEntrega - dataRetirada);

            if (nod.TotalDays < 1)
                viewModel.QtdDiarias = 1;
            else
                viewModel.QtdDiarias = (nod.TotalHours % 24 == 0) ? (int)nod.TotalDays : ((int)nod.TotalDays) + 1;

            viewModel.listaCarrosDisponiveis = BuscarCarrosDisponiveis(viewModel.dataRetirada, viewModel.dataEntrega);


            return View(viewModel);
        }

        public List<CarroViewModel> BuscarCarrosDisponiveis(DateTime dataRetirada, DateTime dataEntrega)
        {
            var listaCarros = TopGear.Api.TopGearApiDataAccess<IEnumerable<Carro>>.Get("carro");
            List<CarroViewModel> listaCarrosDispopniveis = new List<CarroViewModel>();

            foreach (var carro in listaCarros)
            {
                var categoria = TopGear.Api.TopGearApiDataAccess<Categoria>.Get($"categoria/porid/{carro.CategoriaId}");
                CarroViewModel carroViewModel = new CarroViewModel { Id = carro.Id, Ano = carro.Ano, Marca = carro.Marca, Modelo = carro.Modelo, categoria = categoria };
                listaCarrosDispopniveis.Add(carroViewModel);
            }

            return listaCarrosDispopniveis;

        }

        

    }
}