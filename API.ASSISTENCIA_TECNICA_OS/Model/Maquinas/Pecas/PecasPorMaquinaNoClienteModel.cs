using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas
{
    [Table("tab_pecasPorMaquinaCliente")]
    public class PecasPorMaquinaNoClienteModel
    {
        public Guid Id { get; set; }
        public Guid MaquinaClientId { get; set; }
        public Guid PecaId { get; set; }
    }
}
