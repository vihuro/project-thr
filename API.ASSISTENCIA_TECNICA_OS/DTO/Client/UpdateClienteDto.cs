namespace API.ASSISTENCIA_TECNICA_OS.DTO.Client
{
    public class UpdateClienteDto
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string CodigoRadar { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Regiao { get; set; }
        public string Rua { get; set; }
        public string NumeroEstabelecimento { get; set; }
        public Guid UserId { get; set; }
#nullable enable
        public string? Complemento { get; set; }
        public string? NomeContatoCliente { get; set; }
        public string? ContatoTelefone { get; set; }
        public List<Maquina>? MaquinaCliente { get; set; }
    }
}
