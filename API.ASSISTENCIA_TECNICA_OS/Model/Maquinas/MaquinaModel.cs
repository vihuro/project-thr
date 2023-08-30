using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas
{
    [Table("tab_maquina")]
    public class MaquinaModel
    {
        [Key]
        public Guid Id { get; set; }
        public string TipoMaquina { get; set; }
        public bool Ativo { get; set; }
        public virtual List<PecasPorMaquinaModel> Pecas { get; set; }
        public virtual List<PecasPorMaquinaEOrdemModel> PecasPorOrdemServico { get; set; }

    }
}
