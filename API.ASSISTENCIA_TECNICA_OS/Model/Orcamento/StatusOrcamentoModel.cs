using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_statusOrcamento")]
    public class StatusOrcamentoModel
    {
        public Guid Id { get; set; }
        public int OrcamentoId { get; set; }
        public int StatusId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public virtual StatusModel Status { get; set; }
        public virtual UsuarioApontamentoInicioStatusModel UsuarioApontamentoInicio { get; set; }
        public virtual UsuarioApontamentoFimStatusModel UsuarioApontamentFim { get; set; }
        public virtual OrcamentoModel Orcamento { get; set; }
    }
}
