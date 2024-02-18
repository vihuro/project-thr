using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Tecnico
{
    [Table("tab_avalicao_tecnico")]
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public virtual OrcamentoModel Orcamento { get; set; }
        public Guid TecnicoId { get; set; }
        public virtual TecnicoModel Tecnico { get; set; }
        public int Avaliacao { get; set; }
        public EStatusAvaliacao StatusAvaliacao { get; set; }
    }
    public enum EStatusAvaliacao
    {
        PENDENTE,
        AGUARDANDO_GERENCIA,
        FINALIZADO
    }

}
