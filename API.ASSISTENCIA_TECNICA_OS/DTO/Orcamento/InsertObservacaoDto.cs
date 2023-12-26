namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class InsertObservacaoDto
    {
        public int OrcamentoId { get; set; }
        public string Observacao { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
