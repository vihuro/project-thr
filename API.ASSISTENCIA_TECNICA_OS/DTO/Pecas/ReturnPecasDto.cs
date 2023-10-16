namespace API.ASSISTENCIA_TECNICA_OS.DTO.Pecas
{
    public class ReturnPecasDto
    {
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int QuantityPages{ get; set; }
        public List<PecasDto> Pecas { get; set; }
    }
    public class PecasDto
    {
        public Guid Id { get; set; }
        public string CodigoRadar { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Unidade { get; set; }
        public string Familia { get; set; }
        public UsuarioDataHora Cadastro { get; set; }
        public UsuarioDataHora Alteracao { get; set; }
        public string EnderecoImagem { get; set; }
    }
    public class UsuarioDataHora
    {
        public Guid IdUsuario { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
    }
}
