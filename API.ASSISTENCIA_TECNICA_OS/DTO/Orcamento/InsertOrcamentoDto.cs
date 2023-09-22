namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class InsertOrcamentoDto
    {
        public string DescricaoServico { get; set; }
        public double ValorOrcamento { get; set; }
        public Guid UserId { get; set; }
        public Guid MaquinaId { get; set; }
    }
}
