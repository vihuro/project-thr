using API.AUTH.Dto.user;

namespace API.AUTH.Dto.Claims
{
    public class ReturnTypeClaimsDto
    {
        public Guid ClaimId { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
        public UserResumeDateTimeDto Cadastro { get; set; }
        public UserResumeDateTimeDto Alteracao { get; set; }
    }
}
