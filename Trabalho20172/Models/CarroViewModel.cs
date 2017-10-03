using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopGear.Api.Models;

namespace Trabalho20172.Models
{
    public class CarroViewModel
    {
        public int Id { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }
      
        public string Placa { get; set; }
      
        public int Ano { get; set; }

        public int AgenciaId { get; set; }
      
        public Categoria categoria { get; set; }

    }
}