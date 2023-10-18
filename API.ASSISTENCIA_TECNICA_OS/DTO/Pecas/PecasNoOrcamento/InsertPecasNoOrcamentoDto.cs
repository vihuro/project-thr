namespace API.ASSISTENCIA_TECNICA_OS.DTO.Pecas.PecasNoOrcamento
{
    public class InsertPecasNoOrcamentoDto
    {
        public int NumeroOcamento { get; set; }
        public Guid UsuarioId { get; set; }
        public List<PecasResumidaOrcamentoDto> Pecas { get; set; }
    }

    public class PecasResumidaOrcamentoDto
    {
        public Guid PecaId { get; set; }
    }
}
