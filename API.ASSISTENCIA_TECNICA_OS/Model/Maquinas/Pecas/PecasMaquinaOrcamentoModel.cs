using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas
{
    [Table("tab_pecasMaquinaEOrcamento")]
    public class PecasMaquinaOrcamentoModel
    {
        public Guid Id { get; set; }
        public Guid MaquinaId { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
        public Guid PecaId { get; set; }
        public bool Conserto { get; set; }
        public bool Troca { get; set; }
        public virtual PecasModel Peca { get; set; }
        public int OrcamentoId { get; set; }
        public virtual OrcamentoModel Orcamento{ get; set; }
    }
}
