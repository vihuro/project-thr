namespace API.ASSISTENCIA_TECNICA_OS.DTO.Client
{
    public class ReturnClientDto
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string ContatoTelefone { get; set; }
        public string ContatoNome { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Regiao { get; set; }
        public string Rua { get; set; }
        public string NumeroEstabelecimento { get; set; }
        public string Complemento { get; set; }
        public string CodigoRadar { get; set; }
        public UsuarioDto Cadastro { get; set; }
        public UsuarioDto Alteracao { get; set; }
        public List<MaquinaClienteDto> MaquinaCliente { get; set; }

    }
    public class UsuarioDto
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataHora { get; set; }
    }
    public class MaquinaClienteDto
    {
        public Guid Id { get; set; }
        public Guid MaquinaId { get; set; }
        public string CodigoMaquina { get; set; }
        public string TipoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public string Status { get; set; }
    }

}
