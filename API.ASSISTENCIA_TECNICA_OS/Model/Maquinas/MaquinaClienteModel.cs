using API.ASSISTENCIA_TECNICA_OS.Model.Client;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas
{
    [Table("tab_maquina_cliente")]
    public class MaquinaClienteModel
    {
        public Guid Id { get; set; }
        public Guid MaquinaId { get; set; }
        public Guid ClienteId { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
        public virtual ClientModel Client { get; set; }
        public virtual List<PecasPorMaquinaModel> PecasPorMaquinaNoClient { get; set; } 
    }
}
