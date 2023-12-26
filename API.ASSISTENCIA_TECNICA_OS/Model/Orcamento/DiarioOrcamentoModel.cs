using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_diarioOrcamento")]
    public class DiarioOrcamentoModel
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public string Informacao { get; set; }
        public string Tag { get; set; }
        public bool Privado { get; set; }
        public virtual OrcamentoModel Orcamento { get; set; }
        public Guid UsuarioApontamentoId { get; set; }
        public UserModel UsuarioApontamento { get; set; }
        public DateTime DataHoraApontamento { get; set; }
    }
}
