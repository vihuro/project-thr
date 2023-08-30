using System.ComponentModel.DataAnnotations.Schema;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas
{
    [Table("tab_pecaPorMaquina")]
    public class PecasPorMaquinaModel
    {
        public Guid Id { get; set; }
        public Guid PecaId { get; set; }
        public virtual PecasModel Peca { get; set; }
        public Guid MaquinaId { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
    }
}
