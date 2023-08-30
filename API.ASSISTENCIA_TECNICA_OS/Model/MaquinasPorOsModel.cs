using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model
{
    [Table("tab_maquinaPorOs")]
    public class MaquinasPorOsModel
    {

        public Guid Id { get; set; }
        public int OsId { get; set; }
        public virtual OSModel Os { get; set; }
        public Guid MaquinaId { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
    }
}
