namespace API.AUTH.Dto.user
{
    public class UserResumeDateTimeDto
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataHora { get; set; }
    }
}
