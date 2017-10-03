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

        public List<SelectListItem> ListaDeAgencias()
        {
            List<SelectListItem> listaAgencias = new List<SelectListItem>();
            var agencias = TopGear.Api.TopGearApiDataAccess<IEnumerable<Agencia>>.Get("agencia");

            listaAgencias.Add(new SelectListItem { Text = "", Value = "0" });
            //listaAgencias.Add(new SelectListItem { Text = "Aeroporto", Value = "9" });
            //listaAgencias.Add(new SelectListItem { Text = "Teste", Value = "10" });


            foreach (var item in agencias)
            {
                listaAgencias.Add(new SelectListItem { Text = item.Nome, Value = item.Id.ToString() });
            }

            return listaAgencias;
        }
    }
}