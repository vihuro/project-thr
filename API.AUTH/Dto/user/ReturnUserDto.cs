using API.AUTH.Dto.Claims;

namespace API.AUTH.Dto.user
{
    public class ReturnUserDto
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public bool Ativo { get; set; }
        public List<ReturnClaimsForUser> Claims { get; set; }
    }
}
