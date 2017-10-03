﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Index(IsUnique = true)]
        public string Placa { get; set; }
        [Required]
        public int Ano { get; set; }

        public int AgenciaId { get; set; }
        public int CategoriaId { get; set; }

    }
}