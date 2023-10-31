namespace API.ASSISTENCIA_TECNICA_OS.DTO.Status
{
    public class ReturnStatusOnBudgetDto
    {
        public int OrcamentoId { get; set; }
        public int StatusId { get; set; }
        public Guid UsuarioApontamentoId { get; set; }
    }
}
