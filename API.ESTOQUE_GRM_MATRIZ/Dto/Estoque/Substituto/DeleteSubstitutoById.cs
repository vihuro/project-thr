namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto
{
    public class DeleteSubstitutoById
    {
        public Guid ProdutoId { get; set; }
        public Guid SubstitutoId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
