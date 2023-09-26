using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_usuarioApontamentoStatus")]
    public class UsuarioApontamentoStatus
    {
        public Guid Id { get; set; }
        public Guid StatusOrcamentoId { get; set; }
        public StatusOrcamentoModel StatusOrcamento { get; set; }
        public Guid UsuarioApontamentoId { get; set; }
        public UserModel UsuarioApontamento { get; set; }
    }
}
