namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class InsertInformacaoDiarioDto
    {
        public int NumeroOrcamento { get; set; }
        public string Observacao { get; set; }
        public Guid UsuarioId { get; set; }
        public string Tag { get; set; }
        public bool Privado { get; set; }
    }
}
