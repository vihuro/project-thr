namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class UpdateTecnicoNaManutencaoDto
    {
        public int OrcamentoId { get; set; }
        public int TempoEstimado { get; set; }
        public Guid TecnicoId { get; set; }
    }
}
