namespace API.ASSISTENCIA_TECNICA_OS.DTO.Client
{
    public class InsertClientDto
    {
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
        public List<Maquina>? Maquinas { get; set; }
    }
    public class Maquina
    {
        public Guid MaquinaId { get; set; }
        public int TipoAquisicao { get; set; }
        public string? DataSugestaoRetorno { get; set; }
    }

}
