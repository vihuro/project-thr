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
        public string TipoMaquina { get; set; }
    }
    public class ClienteDto
    {
        public Guid ClienteId { get; set; }
        public string NomeCliente { get; set; }
        public string Cnpj { get; set; }    
        public string CodigoRadar { get; set; }
        public string Endereco { get; set; }
    }
}
