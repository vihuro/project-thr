namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto
{
    public class DeleteSubstitutoById
    {
        public int ProdutoId { get; set; }
        public int SubstitutoId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
