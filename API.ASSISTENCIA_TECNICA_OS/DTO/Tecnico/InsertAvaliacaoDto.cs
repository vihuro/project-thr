namespace API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico
{
    public class InsertAvaliacaoDto
    {
        public int OrcamentoId { get; set; }
        public Guid TecnicoId { get; set; }
        public int Avaliacao { get; set; }
    }
}
