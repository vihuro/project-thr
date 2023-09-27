using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_usuarioApontamentoStatusInicio")]
    public class UsuarioApontamentoInicioStatusModel
    {
        public Guid Id { get; set; }
        public Guid StatusOrcamentoId { get; set; }
        public StatusOrcamentoModel StatusOrcamento { get; set; }
        public Guid UsuarioApontamentoInicioId { get; set; }
        public virtual UserModel UsuarioApontamentoInicio { get; set; }

    }
}
