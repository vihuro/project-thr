namespace API.ASSISTENCIA_TECNICA_OS.DTO.Pecas
{
    public class InsertPecaDto
    {
        public string CodigoRadar { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Unidade { get; set; }
        public string Familia { get; set; }
        public Guid UsuarioId { get; set; }

#nullable enable
        public string? EnderecoImagem { get; set; }
    }
}
