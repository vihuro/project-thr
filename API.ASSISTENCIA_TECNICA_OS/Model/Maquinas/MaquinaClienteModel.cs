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
        public StatusMaquinaClienteModel Status { get; set; }
        public ETipoAquisicao TipoAquisicao { get; set; }
        public DateTime? DataRetorno { get; set; }
        public DateTime? DataSugestaoRetorno { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
        public virtual ClientModel Cliente { get; set; }
    }

    public enum StatusMaquinaClienteModel
    {
        LIBERADA = 0,
        AGUARDANDO_ORCAMENTO = 1,
        AGUARDANDO_APROVACAO = 2,
        EM_MANUTENCAO = 3,
        LIMPEZA = 4
    }
    public enum ETipoAquisicao
    {
        VENDA = 0,
        EMPRESTIMO = 1,
    }
}
