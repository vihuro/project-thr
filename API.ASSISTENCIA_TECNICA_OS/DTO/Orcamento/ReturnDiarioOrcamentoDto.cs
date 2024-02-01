namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento
{
    public class ReturnDiarioOrcamentoDto
    {
        public int Id { get; set; }
        public string NumeroOrcamento { get; set; }
        public string Informacao { get; set; }
        public bool Privado { get; set; }
        public string Tag { get; set; }
        public string UsuarioApontamentoId { get; set; }
        public string UsuarioApontamentoNome { get; set; }
        public string UsuarioApontamentoApelido { get; set; }
        public DateTime DataHoraApontamento { get; set; }
    }
}
