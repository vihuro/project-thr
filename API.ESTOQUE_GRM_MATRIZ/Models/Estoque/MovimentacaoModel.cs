using API.ESTOQUE_GRM_MATRIZ.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ESTOQUE_GRM_MATRIZ.Models.Estoque
{
    [Table("tab_movimentacao")]
    public class MovimentacaoModel
    {
        public Guid Id { get; set; }
        public string TipoMovimentacao { get; set; }
        public int MaterialId { get; set; }
        public virtual EstoqueModel Material { get; set; }
        public double QuantidadeOrigem { get; set; }
        public double QuantidadeDestino { get; set; }
        public double QuantidadeMovimentada { get; set; }
        public string Destino { get; set; }
        public DateTime DataHoraMovimentacao { get; set; }
        public Guid UsuarioMovimentacaoId { get; set; }
        public virtual UserAuthModel UsuarioMovimentacao { get;set; }
    }
}
