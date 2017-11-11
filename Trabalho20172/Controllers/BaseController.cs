using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.DataAccess;
using TopGear.Api.Models;

namespace Trabalho20172.Controllers
{
    public class BaseController : Controller
    {

        public JsonResult CadastrarCliente(Cliente cliente)
        {
            string cpf = cliente.CPF;
            cliente.CPF = Regex.Replace(cpf, @"\D+", String.Empty);
            //cliente.CPF = cpf.Replace("-", string.Empty);

            TopGearApiDataAccess<Cliente>.Post(cliente, "cliente");

            return Json(new { Status = "ok" });
        }
        
        public Cliente BuscarDadosClienteLogado()
        {
            Cliente cliente = null;
            if(Session["idCliente"] != null)
            {
                cliente = ClienteApiDataAccess.Get($"cliente/porid/{(int)Session["idCliente"]}");
                ViewBag.ClienteLogado = cliente;
            }

            return cliente;
        }

        public List<SelectListItem> ListaDeAgencias()
        {
            List<SelectListItem> listaAgencias = new List<SelectListItem>();
            var agencias = TopGearApiDataAccess<IEnumerable<Agencia>>.Get("agencia");

            listaAgencias.Add(new SelectListItem { Text = "", Value = "0" });
          
            foreach (var item in agencias)
            {
                listaAgencias.Add(new SelectListItem { Text = item.Nome, Value = item.Id.ToString() });
            }

            return listaAgencias;
        }

        public int CalcularQuantidadeDiarias(DateTime retirada, DateTime entrega)
        {
            TimeSpan nod = (entrega - retirada);
            int QtdDiarias = 0;
            if (nod.TotalDays < 1)
                QtdDiarias = 1;
            else
                QtdDiarias = (nod.TotalHours % 24 == 0) ? (int)nod.TotalDays : ((int)nod.TotalDays) + 1;

            return QtdDiarias;
        }
    }
}
