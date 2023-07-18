namespace API.AUTH.Dto.user
{
    public class ChangePassword
    {
        public Guid UserId { get; set; }
        public string Senha { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
    }
}
