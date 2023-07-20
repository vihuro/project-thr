using API.ESTOQUE_GRM_MATRIZ.Models.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Models.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Models.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Models.User;
using Microsoft.EntityFrameworkCore;

namespace API.ESTOQUE_GRM_MATRIZ.ContextBase
{
    public class Context : DbContext
    {
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstoqueModel>()
                .HasMany(c => c.Substituos)
                .WithOne(u => u.Substituto)
                .HasForeignKey(u => u.SubstitutoId);
        }
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<UserAuthModel> User { get; set; }
        public DbSet<EstoqueModel> Estoque { get; set; }
        public DbSet<SubstitutoModel> Substituto { get; set; }
        public DbSet<TipoMaterialModel> TipoMaterial { get; set; }
    }
}
