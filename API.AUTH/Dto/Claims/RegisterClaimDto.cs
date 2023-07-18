namespace API.AUTH.Dto.Claims
{
    public class RegisterClaimDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
