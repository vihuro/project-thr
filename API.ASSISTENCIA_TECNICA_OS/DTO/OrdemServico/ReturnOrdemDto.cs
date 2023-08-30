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
        public List<Pecas> PecasDaMaquina { get; set; }
    }
    public class Pecas
    {
        public Guid PecaId { get; set; }
        public string Peca { get; set; }
        public bool Conserto { get; set; }
        public bool Troca { get; set; }
        public string EnderecoImagem { get; set; }

    }
}

