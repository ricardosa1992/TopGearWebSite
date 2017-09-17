using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trabalho20172.Models
{
    public class LocacaoViewModel
    {
        public int idLocalRetirada { get; set; }

        public int idLocalEntrega { get; set; }

        public List<SelectListItem> ListaDeAgencias { get; set; }
    }
}