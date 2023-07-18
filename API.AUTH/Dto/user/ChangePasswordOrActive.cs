namespace API.AUTH.Dto.user
{
    public class ChangePasswordOrActive
    {
        public Guid UserId { get; set; }
        public string Senha { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public bool? Ativo { get; set; }
    }
}
