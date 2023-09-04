﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas
{
    [Table("tab_pecas")]
    public class PecasModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
#nullable enable
        public List<string>? EnderecoImagem { get; set; }
    }
}