namespace API.ASSISTENCIA_TECNICA_OS.DTO.Maquina
{
    public class InsertMaquinaDto
    {
        public string CodigoMaquina { get; set; }
        public string DescricaoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public string Unidade { get; set; }
        public Guid UserId { get; set; }
#nullable enable
        public List<InsertMaquinaPecasDto>? Pecas { get; set;}
    }
    public class InsertMaquinaPecasDto
    {
        public Guid IdPeca { get; set; }
    }
}
