using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_status")]
    public class StatusModel
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
