namespace API.ASSISTENCIA_TECNICA_OS.DTO.User
{
    public class ReturnListUserDto
    {

        public int TotalUsers { get; set; }
        public List<ReturnUserAuthDto> DataUsers { get; set; }
    }
    public class ReturnUserAuthDto
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool Ativo { get; set; }

    }
    public class ReturnClaimsForUser
    {
        public Guid id { get; set; }
        public Guid ClaimId { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
    }
}
