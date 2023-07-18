namespace API.AUTH.Dto.Claims
{
    public class ReturnClaimsForUser
    {
        public Guid ClaimId { get; set; }
        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
    }
}
