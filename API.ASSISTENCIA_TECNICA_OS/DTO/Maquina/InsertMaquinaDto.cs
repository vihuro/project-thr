namespace API.ASSISTENCIA_TECNICA_OS.DTO.Maquina
{
    public class InsertMaquinaDto
    {
        public string TipoMaquina { get; set; }
        public List<InsertMaquinaPecasDto> Pecas { get; set;}
    }
    public class InsertMaquinaPecasDto
    {
        public Guid IdPeca { get; set; }
    }
}
