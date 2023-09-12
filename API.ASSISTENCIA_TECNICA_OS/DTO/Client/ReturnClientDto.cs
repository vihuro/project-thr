namespace API.ASSISTENCIA_TECNICA_OS.DTO.Client
{
    public class ReturnClientDto
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string ContatoTelefone { get; set; }
        public string ContatoNome { get; set; }
        public string Endereco { get; set; }
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
        public Guid MaquinaId { get; set; }
        public string TipoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public string Status { get; set; }
    }

}
