namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class UpdateUltimoClienteCompraDto
    {
        public Guid UsuarioId { get; set; }
        public int MaterialId { get; set; }
#nullable enable
        public string? ClienteUltimaCompra1 { get; set; }
        public string? CodigoClienteUltimaCompra1 { get; set; }
        public string? ClienteUltimaCompra2 { get; set; }
        public string? CodigoClienteUltimaCompra2 { get; set; }
        public string? ClienteUltimaCompra3 { get; set; }
        public string? CodigoClienteUltimaCompra3 { get; set; }
    }
}
