using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;

namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Movimentacao
{
    public class ReturnMovimentacao
    {
        public Guid MovimentacaoId { get; set; }
        public ReturnEstoqueResumidoDto MaterialMovimentado { get; set; }
        public double QuantidadeOrigem { get; set; }
        public double QuantidadeMovimentacao { get; set; }
        public double NovaQuantidade { get; set; }
        public string TipoMovimentacao { get; set; }
        public UsertDateTime UsuarioMovimentacao { get; set; }
        public string Destino { get; set; }
    }
}
