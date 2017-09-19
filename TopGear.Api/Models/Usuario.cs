using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGear.Api.Models
{
    public class Usuario : IEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Token { get; set; }
    }
}
