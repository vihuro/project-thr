namespace API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente
{
    public class InsertMaquinaInClientDto
    {
        public Guid MaquinaId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DataRetorno { get; set; }
        public DateTime DataSugeridaRetorno { get; set; }
        public ETipoAquisicaoDto TipoAquisicao { get; set; }
    }
    public enum ETipoAquisicaoDto 
    {
        ESTOQUE = 0,
        VENDA = 1,
        EMPRESTIMO = 2,
    }

}
