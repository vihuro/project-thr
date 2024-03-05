namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class InsertNumeroOrcamentoDto
    {
        public int OrcamentoId { get; set; }
        public string NumeroOrcamentoRadar { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
