using System.Collections.Generic;
using System.Web.Mvc;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LocacaoViewModel modeloDaView = new LocacaoViewModel();
            modeloDaView.ListaDeAgencias = ListaDeAgencias();

            return View(modeloDaView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public List<SelectListItem> ListaDeAgencias()
        {
            List<SelectListItem> listaAgencias = new List<SelectListItem>();
            var agencias = TopGear.Api.TopGearApiDataAccess<Agencia>.Get("agencia");

            listaAgencias.Add(new SelectListItem { Text = "", Value = "0" });
            //listaAgencias.Add(new SelectListItem { Text = "Aeroporto", Value = "9" });
            //listaAgencias.Add(new SelectListItem { Text = "Teste", Value = "10" });


            foreach (var item in agencias)
            {
                listaAgencias.Add(new SelectListItem { Text = item.Bairro, Value = item.Id.ToString() });
            }

            return listaAgencias;
        }

    }
}