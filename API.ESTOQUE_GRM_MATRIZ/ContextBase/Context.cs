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
            modelBuilder.Entity<SubstitutoModel>()
                .HasOne(s => s.MaterialEstoque)
                .WithMany(e => e.Substituos)
                .HasForeignKey(s => s.MaterialEstoqueId)
                .OnDelete(DeleteBehavior.Restrict); // Defina o comportamento de exclusão de acordo com o que você precisa

            modelBuilder.Entity<SubstitutoModel>()
                .HasOne(s => s.Substituto)
                .WithMany()
                .HasForeignKey(s => s.SubstitutoId)
                .OnDelete(DeleteBehavior.Restrict); // Defina o comportamento de exclusão de acordo com o que você precisa
        }
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<UserAuthModel> User { get; set; }
        public DbSet<EstoqueModel> Estoque { get; set; }
        public DbSet<SubstitutoModel> Substituto { get; set; }
        public DbSet<TipoMaterialModel> TipoMaterial { get; set; }
        public DbSet<LocalArmazenagemModel> Local { get; set; }
    }
}
