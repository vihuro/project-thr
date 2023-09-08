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
    }
}
