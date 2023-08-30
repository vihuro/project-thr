using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;

namespace API.ASSISTENCIA_TECNICA_OS.Model.OrdemServico
{
    [Table("tab_ordemServico")]
    public class OrdemServicoModel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public virtual List<PecasPorMaquinaEOrdemModel> MaquinaPorOs { get; set; }
    }
}
