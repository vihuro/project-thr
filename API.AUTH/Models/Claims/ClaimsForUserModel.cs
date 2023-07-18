using API.AUTH.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.AUTH.Models.Claims
{
    [Table("tab_claimsForUser")]
    public class ClaimsForUserModel
    {
        public Guid Id { get; set; }
        public Guid ClaimsId { get; set; }
        public virtual TypeClaimsModel TypeClaims { get; set; }
        public Guid UserClaimId { get; set; }
        public virtual UserModel UserClaims { get; set; }

    }
}
