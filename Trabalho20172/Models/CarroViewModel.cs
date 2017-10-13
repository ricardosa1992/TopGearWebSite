using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopGear.Api.Models;

namespace Trabalho20172.Models
{
    public class CarroViewModel: Carro
    {
        public Categoria categoria { get; set; }

    }
}