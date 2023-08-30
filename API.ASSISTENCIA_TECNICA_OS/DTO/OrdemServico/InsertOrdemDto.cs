namespace API.ASSISTENCIA_TECNICA_OS.DTO.OrdemServico
{
    public class InsertOrdemDto
    {
        public string Descricao { get; set; }
#nullable enable
        public List<InsertOrdemListMaquinas>? Maquinas { get; set; }
    }
}
