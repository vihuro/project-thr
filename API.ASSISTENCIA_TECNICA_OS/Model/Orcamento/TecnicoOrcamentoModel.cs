using API.ASSISTENCIA_TECNICA_OS.Model.Tecnico;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_tecnicoOrcamento")]
    public class TecnicoOrcamentoModel
    {
        public Guid Id { get; set; }
        public Guid TecnicoId { get; set; }
        public int OrcamentoId { get; set; }
        public virtual TecnicoModel Tecnico { get; set; }
        public OrcamentoModel Orcamento { get; set; }
    }

}
