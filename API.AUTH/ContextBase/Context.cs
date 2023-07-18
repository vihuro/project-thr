using API.AUTH.Models.Claims;
using API.AUTH.Models.User;
using Microsoft.EntityFrameworkCore;

namespace API.AUTH.ContextBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions <Context> options) : base(options) { }
        public DbSet<ClaimsForUserModel> ClaimsForUserModel { get; set; }
        public DbSet<TypeClaimsModel> TyepClaimsModel { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
