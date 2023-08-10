namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class UpdateQuantidadeOrUnidadeDto
    {
        public Guid ProdutoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TipoId { get; set; }
        public string Unidade { get; set; }
    }
}
