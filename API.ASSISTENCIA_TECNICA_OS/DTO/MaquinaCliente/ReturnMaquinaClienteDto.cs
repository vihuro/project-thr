namespace API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente
{
    public class ReturnMaquinaClienteDto
    {
        public Guid Id { get; set; }
        public MaquinaDto Maquina { get; set; }
        public ClienteDto Cliente { get; set; }
    }
    public class MaquinaDto
    {
        public Guid MaquinaId { get; set; }
        public string CodigoMaquina { get; set; }
        public string DescricaoMaquina { get; set; }
        public DateTime DataSugestaoRetorno { get; set; }
        public string TipoAquisicao { get; set; }
        public List<ReturnPecasInMaquinaInClienteDto> Pecas { get; set; }
    }
    public class ReturnPecasInMaquinaInClienteDto
    {
        public Guid PecaId { get; set; }
        public string CodigoPeca { get; set; }
        public string DescricaoPeca { get; set; }
        public double Preco { get; set; }
    }
    public class ClienteDto
    {
        public Guid ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string Cnpj { get; set; }
        public string CodigoRadar { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Regiao { get; set; }
        public string NomeRua { get; set; }
        public string NumeroEstabelecimento { get; set; }
        public string Complemento { get; set; }
        public string ContatoTelefoneCliente { get; set; }
        public string ContatoNomeCliente { get; set; }
    }
}
