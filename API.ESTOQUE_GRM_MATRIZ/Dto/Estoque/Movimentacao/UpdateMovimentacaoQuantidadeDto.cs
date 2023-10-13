namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Movimentacao
{
    public class UpdateMovimentacaoQuantidadeDto
    {
        public int MaterialId { get; set; }
        public double QuantidadeMovimentada { get; set; }

        public Guid UsuarioId { get; set; }
        public TipoMovimentacao Tipo { get; set; }
#nullable enable
        public string? Destino { get; set; }
    }
}
