namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class UpdateTecnicoNoOrcamentoOuNaManutencaoDto
    {
        public int OrcamentoId { get; set; }
        public int TempoEstimadoOrcamento { get; set; }
#nullable enable
        public string? Observacao { get; set; }
        public Guid TecnicoId { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
    }
}
