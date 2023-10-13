namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class UpdateQuantidadeDto
    {
        public int MaterialId { get; set; }
        public double Quantidade { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
