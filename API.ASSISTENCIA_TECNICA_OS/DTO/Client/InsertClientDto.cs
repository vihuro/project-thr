namespace API.ASSISTENCIA_TECNICA_OS.DTO.Client
{
    public class InsertClientDto
    {
        public string Nome { get; set; }
        public string CodigoRadar { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string NomeContatoCliente { get; set; }
        public string ContatoTelefone { get; set; }
#nullable enable
        public List<Maquina>? Maquinas { get; set; }
    }
    public class Maquina
    {
        public Guid MaquinaId { get; set; }
    }

}
