namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto
{
    public class UpdateSubstitutoDto
    {
        public Guid ProdutoId { get; set; }
        public Guid SubstitutoId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
