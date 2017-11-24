using System.Collections.Generic;
using System.Web.Mvc;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class HomeController : BaseController
    {
     

        public ActionResult Index()
        {
            EnviarEmail();
            BuscarDadosClienteLogado();
            LocacaoViewModel modeloDaView = new LocacaoViewModel();
            modeloDaView.ListaDeAgencias = ListaDeAgencias();

            return View(modeloDaView);
        }

        public ActionResult Teste()
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

    }
}