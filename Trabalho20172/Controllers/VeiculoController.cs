using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        [HttpPost]
        public ActionResult Veiculos()
        {

            LocacaoViewModel viewModel = new LocacaoViewModel();
            viewModel.ListaDeAgencias = ListaDeAgencias();

            //Obtendo os parâmetros selecionados para retirada/entrega
            int idLocalRetirada = Convert.ToInt32(Request.Form["listaLocalRetirada"]);
            int idLocalEntrega = Convert.ToInt32(Request.Form["listaLocalEntrega"]);
            var horaRetirada = Request.Form["pick-up-time"];
            var horaEntrega = Request.Form["drop-off-time"];

            var dataRetirada = Request.Form["pick-up-date"];

            viewModel.dataRetirada = Convert.ToDateTime(Request.Form["pick-up-date"]);
            viewModel.dataEntrega = Convert.ToDateTime(Request.Form["drop-off-date"]);


            //Obtendo a Agencia de retirada
            viewModel.localRetirada =TopGear.Api.TopGearApiDataAccess<Agencia>.Get(idLocalRetirada, "agencia");

            //Obtendo a Agencia de entrega != retirada
             viewModel.localEntrega = (idLocalRetirada != idLocalEntrega && idLocalEntrega != 0) ? TopGear.Api.TopGearApiDataAccess<Agencia>.Get(idLocalEntrega, "agencia") : viewModel.localRetirada;

            //Buscar os Carros disponiveis
            viewModel.listaCarrosDisponiveis = TopGear.Api.TopGearApiDataAccess<Carro>.Get("carro");

            return View(viewModel);
        }

        public List<SelectListItem> ListaDeAgencias()
        {
            List<SelectListItem> listaAgencias = new List<SelectListItem>();
            var agencias = TopGear.Api.TopGearApiDataAccess<Agencia>.Get("agencia");

            listaAgencias.Add(new SelectListItem { Text = "", Value = "0" });
            foreach (var item in agencias)
            {
                listaAgencias.Add(new SelectListItem { Text = item.Bairro, Value = item.Id.ToString() });
            }

            return listaAgencias;
        }

    }
}