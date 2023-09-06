namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class UpdatePrecoDto
    {
        public Guid ProdutoId { get; set; }
        public Guid UsuarioId { get; set; }
        public double Preco { get; set; }
    }
}
