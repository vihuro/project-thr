namespace API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente
{
    public class InsertMaquinaInClientDto
    {
        public Guid MaquinaId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid UserId { get; set; }
    }
}
