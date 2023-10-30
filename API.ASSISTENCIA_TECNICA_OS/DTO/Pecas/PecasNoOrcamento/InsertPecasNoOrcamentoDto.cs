namespace API.ASSISTENCIA_TECNICA_OS.DTO.Pecas.PecasNoOrcamento
{
    public class InsertPecasNoOrcamentoDto
    {
        public int NumeroOrcamento { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid PecaId { get; set; }
        public int Quantidade { get; set; }
        public bool Troca { get; set; }
        public bool Conserto { get; set; }
        public bool Reaproveitamento { get; set; }
    }
}
