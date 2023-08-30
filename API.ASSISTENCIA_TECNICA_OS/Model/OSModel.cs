using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model
{
    [Table("tab_ordemServico")]
    public class OSModel
    {
        [Key]
        public int Os { get;set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public virtual List<MaquinasPorOsModel> MaquinaPorOs { get; set; }
    }
}
