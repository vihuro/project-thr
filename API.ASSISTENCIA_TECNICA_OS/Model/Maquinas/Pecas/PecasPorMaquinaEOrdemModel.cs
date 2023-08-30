using API.ASSISTENCIA_TECNICA_OS.Model.OrdemServico;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas
{
    [Table("tab_pecas_por_maquina_ordem_servico")]
    public class PecasPorMaquinaEOrdemModel
    {
        public Guid Id { get; set; }
        public Guid MaquinaId { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
        public Guid PecaId { get; set; }
        public bool Conserto { get; set; }
        public bool Troca { get; set; }
        public virtual PecasModel Peca { get; set; }
        public int OrdemServicoId { get; set; }
        public virtual OrdemServicoModel OrdemServico { get; set; }
    }
}
