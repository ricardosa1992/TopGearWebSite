using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.Models;

namespace Trabalho20172.Controllers
{
    public class BaseController : Controller
    {

        public JsonResult EfetuarLogin(string login, string senha)
        {
            //Buscar o cliente se estiver cadastrado
            var cliente = TopGear.Api.TopGearApiDataAccess<Cliente>.Get($"cliente/porid/{login}");
            return (cliente != null) ? Json(new { Status = "ok", idCliente = cliente.Id }) : Json(new { Status = "Nok" });

        }

        public List<SelectListItem> ListaDeAgencias()
        {
            List<SelectListItem> listaAgencias = new List<SelectListItem>();
            var agencias = TopGear.Api.TopGearApiDataAccess<IEnumerable<Agencia>>.Get("agencia");

            listaAgencias.Add(new SelectListItem { Text = "", Value = "0" });
          
            foreach (var item in agencias)
            {
                listaAgencias.Add(new SelectListItem { Text = item.Nome, Value = item.Id.ToString() });
            }

            return listaAgencias;
        }
    }
}
