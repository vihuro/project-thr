using API.AUTH.Dto.user;

namespace API.AUTH.Dto.ClaimsForUser
{
    public class ReturnClaimsForUserDto
    {
        public Guid ClaimId { get; set; }
        public string ClaimValue { get; set; }
        public string ClaimName { get; set; }
        public UserResumeWithoutDateOrTime UsuarioClaim { get; set; }
        public UserResumeDateTimeDto Cadastro { get; set; }
        public UserResumeDateTimeDto Alteracao{get;set; }
    }
}
