using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGear.Api.Models
{
    public class Response<T>
    {
        public bool Sucesso { get; set; }

        public T Dados { get; set; }

        public string Mensagem { get; set; }
    }
}
