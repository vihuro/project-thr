namespace API.ASSISTENCIA_TECNICA_OS.DTO.Pecas
{
    public class UpdatePecaDto
    {
        public Guid PecaId { get; set; }
        public string CodigoRadar { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public Guid UsuarioId { get; set; }

#nullable enable
        public string? EnderecoImagem { get; set; }
    }
}
