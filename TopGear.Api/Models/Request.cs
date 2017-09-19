using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGear.Api.Models
{
    public class Request<T>
    {
        public string Token { get; set; };

        public T Dados { get; set; } 
    }
}
