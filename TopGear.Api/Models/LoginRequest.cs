using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGear.Api.Models
{
    public class LoginRequest : BaseRequest
    {
        public string CPF { get; set; }
        public string Senha { get; set; }
    }
}
