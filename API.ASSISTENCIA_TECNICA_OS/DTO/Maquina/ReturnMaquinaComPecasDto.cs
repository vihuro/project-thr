namespace API.ASSISTENCIA_TECNICA_OS.DTO.Maquina
{
    public class ReturnMaquinaComPecasDto
    {
        public  Guid Id { get; set; }
        public string Codigo { get; set; }
        public string DescricaoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public bool Ativo { get; set; }
        public bool Atribuida { get; set; }
        public UserDto Cadastro { get; set; }
        public UserDto Alteracao { get; set; }
        public List<PecaMaquinaDto> Pecas { get; set; }
    }
    public class PecaMaquinaDto
    {
        public Guid PecaId { get; set; }
        public string CodigoRadar { get;set; }
        public string DescricaoPeca { get; set; }
        public double Preco { get; set; }
    }
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
    }
}
