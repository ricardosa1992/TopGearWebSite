using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGear.Api.Models
{
   public class RequestCarrosDisponiveis : BaseRequest
    {
        [Required]
        public DateTime Inicial { get; set; }
        [Required]
        public DateTime Final { get; set; }
        public int? AgenciaId { get; set; }
        public int? ItemId { get; set; }
    }
}
