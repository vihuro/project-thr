namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class UpdateStatusOnBudgetDto
    {
        public Guid UsuarioId { get; set; }
        public Guid MaquinaId { get; set; }
        public int NumeroOrcamento { get; set; }
        public string Observacao { get; set; }
        public int TempoEstimadoOrcamento { get; set; }
        public int TempoEstimadoManutencao { get; set; }
        public int StatusId { get; set; }
    }
}
