using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.Models;

namespace Trabalho20172.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        [HttpPost]
        public ActionResult Veiculos()
        {
            //Obtendo os parâmetros selecionados para retirada/entrega
            int idLocalRetirada = Convert.ToInt32(Request.Form["listaLocalRetirada"]);
            var dataRetirada = Request.Form["pick-up-date"];
            var horaRetirada = Request.Form["pick-up-time"];
            int idLocalEntrega = Convert.ToInt32(Request.Form["listaLocalRetirada"]);
            var dataEntrega = Request.Form["drop-off-date"];
            var horaEntrega = Request.Form["drop-off-time"];

            //Obtendo a Agencia de retirada
            var agenciaRetirada = TopGear.Api.TopGearApi<IEnumerable<Agencia>>.Get(idLocalRetirada,"agencia");

            //Obtendo a Agencia de entrega != retirada
            var agenciaEntrega = (idLocalRetirada != idLocalEntrega) ? TopGear.Api.TopGearApi<IEnumerable<Agencia>>.Get(idLocalEntrega, "agencia") : agenciaRetirada;

            return View();
        }
    }
}