using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TopGear.Api.DataAccess;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class AcessoController : Controller
    {
        //View Index
        public ActionResult Index()
        {
            Session.RemoveAll();

            return View();
        }

        public JsonResult EfetuarLogin(string login, string senha)
        {
            if (ModelState.IsValid)
            {
                //Verificar aqui o login
                Cliente cliente = ClienteApiDataAccess.Login(login, senha);

                if (cliente != null)
                {
                    Session["idCliente"] = cliente.Id;
                    Sessao.IdUsuarioLogado = cliente.Id;
                    return Json(new { Status = "ok", IdCliente = cliente.Id});

                }

                ModelState.Clear();
            }
            return Json(new { Status = "Nok" });
        }

        public ActionResult SairSessao()
        {
            Session["idCliente"] = null;
            Sessao.IdUsuarioLogado = 0;
            return RedirectToAction("Index", "Home");
        }

    }
}