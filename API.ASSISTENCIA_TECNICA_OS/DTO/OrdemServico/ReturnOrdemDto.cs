namespace API.ASSISTENCIA_TECNICA_OS.DTO.OrdemServico
{
    public class ReturnOrdemDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } 
        public List<ReturnMaquinaDto> Maquinas { get; set; }

    }
    public class ReturnMaquinaDto
    {
        public Guid MaquinaId { get; set; }
        public string Maquina { get; set; }
    }
}
