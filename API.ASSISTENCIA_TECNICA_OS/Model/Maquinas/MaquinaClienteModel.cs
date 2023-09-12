using API.ASSISTENCIA_TECNICA_OS.Model.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas
{
    [Table("tab_maquina_cliente")]
    public class MaquinaClienteModel
    {
        public Guid Id { get; set; }
        public Guid MaquinaId { get; set; }
        public Guid ClienteId { get; set; }
        public Status Status { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
        public virtual ClientModel Cliente { get; set; }
    }

    public enum Status
    {
        LIBERADA,
        AGUARDANDO_ORCAMENTO,
        AGUARDANDO_APROVACAO,
        EM_MANUTENCAO
    }
}
