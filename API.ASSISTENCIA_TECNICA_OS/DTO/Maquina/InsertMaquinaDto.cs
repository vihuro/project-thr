namespace API.ASSISTENCIA_TECNICA_OS.DTO.Maquina
{
    public class InsertMaquinaDto
    {
        public string TipoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public Guid UserId { get; set; }
#nullable enable
        public List<InsertMaquinaPecasDto>? Pecas { get; set;}
    }
    public class InsertMaquinaPecasDto
    {
        public Guid IdPeca { get; set; }
    }
}
