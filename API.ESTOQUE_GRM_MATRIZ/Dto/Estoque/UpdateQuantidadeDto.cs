namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class UpdateQuantidadeDto
    {
        public Guid MaterialId { get; set; }
        public double Quantidade { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
