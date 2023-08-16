using API.AUTH.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.AUTH.Models.Claims
{
    [Table("tab_claimsForUser")]
    public class ClaimsForUserModel
    {
        [Key()]
        public Guid Id { get; set; }
        public Guid TypeClaimsId { get; set; }
        public virtual TypeClaimsModel TypeClaims { get; set; }
        public Guid UserClaimId { get; set; }
        public virtual UserModel UserClaim { get; set; }
    }
}
