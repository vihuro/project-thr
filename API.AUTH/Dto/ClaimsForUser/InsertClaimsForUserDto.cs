namespace API.AUTH.Dto.ClaimsForUser
{
    public class InsertClaimsForUserDto
    {
        public Guid ClaimId { get; set; }
        public Guid UserClaimsId { get;set; }
        public Guid UserRegisterId { get; set; }
    }
}
