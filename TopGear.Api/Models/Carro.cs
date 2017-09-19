using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopGear.Api.Models
{
    public class Carro : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        [StringLength(7)]
        public string Placa { get; set; }
        [Required]
        public int Ano { get; set; }

        public bool EmManutencao { get; set; } = false;

        public virtual Agencia Agencia { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}