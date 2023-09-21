namespace API.ASSISTENCIA_TECNICA_OS.DTO.Maquina
{
    public class UpdateMaquinaDto
    {
        public Guid MaquinaId { get; set; }
        public string CodigoMaquina { get; set; }
        public string DescricaoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public bool Ativo { get; set; }
        public Guid UserId { get; set; }
        public List<ListPecasInMaquinaDto> Pecas { get; set; }

    }
    public class ListPecasInMaquinaDto
    {
        public Guid IdPeca { get; set; }
    }
}
