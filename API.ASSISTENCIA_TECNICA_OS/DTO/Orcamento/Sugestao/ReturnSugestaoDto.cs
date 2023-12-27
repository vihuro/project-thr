namespace API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento.Sugestao
{
    public class ReturnSugestaoDto
    {
        public int Id { get; set; }
        public string SugestaoManutencao { get; set; }
        public string Status { get; set; }
        public CriacaoSugestacaoManutencao UsuarioSugestao { get;set; }
        public DateTime DataCobranca { get; set; }
        public MaquinaSugerida MaquinaSugerida { get; set; }
        
    }

    public class CriacaoSugestacaoManutencao
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataHoraCriacaoSugestacao { get; set; }
    }
    public class MaquinaSugerida
    {
        public Guid MaquinaId { get; set; }
        public string CodigoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public string DescricaoMaquina { get; set; }
    }

}
