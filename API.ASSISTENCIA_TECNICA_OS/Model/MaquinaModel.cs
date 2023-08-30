using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model
{
    [Table("tab_maquina")]
    public class MaquinaModel
    {
        [Key]
        public Guid Id { get; set; }
        public string TipoMaquina { get; set; }
        public bool Ativo { get; set; }

    }
}
