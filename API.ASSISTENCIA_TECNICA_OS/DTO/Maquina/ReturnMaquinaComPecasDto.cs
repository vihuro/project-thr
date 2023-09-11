namespace API.ASSISTENCIA_TECNICA_OS.DTO.Maquina
{
    public class ReturnMaquinaComPecasDto
    {
        public  Guid Id { get; set; }
        public string TipoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public bool Ativo { get; set; }
        public UserDto Cadastro { get; set; }
        public UserDto Alteracao { get; set; }
        public List<Pecas> Pecas { get; set; }
    }
    public class Pecas
    {
        public Guid PecaId { get; set; }
        public string Peca { get; set; }
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
