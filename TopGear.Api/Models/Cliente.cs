using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TopGear.Api.Models
{
    public class Cliente : IEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [Required]
        [StringLength(11)]
        [Index(IsUnique = true)]
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cartao { get; set; }
        public string Senha { get; set; }
        
        public virtual ICollection<Locacao> Locacoes { get; set; }
    }
}