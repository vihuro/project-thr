﻿using API.ESTOQUE_GRM_MATRIZ.Models.User;

namespace API.ESTOQUE_GRM_MATRIZ.Models.Estoque
{
    public class LocalArmazenagemModel
    {
        public Guid Id { get; set; }
        public string Local { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UserAuthModel UsuarioCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public virtual UserAuthModel UsuarioAlteracao { get; set; }
    }
}
