using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.Models;

namespace Trabalho20172.Models
{
    public class LocacaoViewModel
    {
        public Agencia localRetirada { get; set; }

        public Agencia localEntrega { get; set; }

        public DateTime dataRetirada { get; set; }

        public DateTime dataEntrega { get; set; }

        public IEnumerable<Carro> listaCarrosDisponiveis = new List<Carro>();

        public List<SelectListItem> ListaDeAgencias { get; set; }
    }
}