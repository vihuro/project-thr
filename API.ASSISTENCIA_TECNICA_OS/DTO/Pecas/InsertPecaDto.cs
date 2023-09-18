namespace API.ASSISTENCIA_TECNICA_OS.DTO.Pecas
{
    public class InsertPecaDto
    {
        public string CodigoRadar { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public Guid UsuarioId { get; set; }

#nullable enable
        public List<string>? EnderecoImagens { get; set; }
    }
}
