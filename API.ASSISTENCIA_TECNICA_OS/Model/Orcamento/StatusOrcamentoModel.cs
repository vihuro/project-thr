using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_statusOrcamento")]
    public class StatusOrcamentoModel
    {
        public Guid Id { get; set; }
        public int OrcamentoId { get; set; }
        public Guid StatusId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public Guid UsuarioApontamentoInicioId { get; set; }
        public virtual UserModel UsuarioApontamentoInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public Guid UsuarioApontamentoFimId { get; set; }
        public virtual UserModel UsuarioApontamentoFim { get; set; }
        public virtual OrcamentoModel Orcamento { get; set; }
        public virtual StatusModel Status { get; set; }
    }
}
