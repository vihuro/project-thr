namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento.Sugestao
{
    public class InsertSugestaoDto
    {
        public string DescricaoSugestao { get; set; }
        public Guid UsuarioSugestaoId { get; set; }
        public Guid MaquinaSugestaoId { get; set; }
        public DateTime DataCobranca { get; set; }
    }
}
