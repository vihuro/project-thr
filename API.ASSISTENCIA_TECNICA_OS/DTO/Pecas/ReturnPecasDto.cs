namespace API.ASSISTENCIA_TECNICA_OS.DTO.Pecas
{
    public class ReturnPecasDto
    {
        public Guid Id { get; set; }
        public string CodigoRadar { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
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
