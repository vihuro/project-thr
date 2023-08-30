using API.ASSISTENCIA_TECNICA_OS.Model;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.ContextBase
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<UserModel> User { get; set; }
        public DbSet<OSModel> Os { get; set; }
        public DbSet<PecasModel> Pecas { get; set; }
        public DbSet<MaquinaModel> Maquina { get; set; }
        public DbSet<MaquinasPorOsModel> MaquinaPorOs { get; set; }
        public DbSet<PecasPorMaquinaModel> PecasPorMaquina { get; set; }

    }
}
