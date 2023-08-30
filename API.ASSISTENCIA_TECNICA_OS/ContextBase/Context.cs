using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.OrdemServico;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.ContextBase
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<UserModel> User { get; set; }
        public DbSet<OrdemServicoModel> Os { get; set; }
        public DbSet<PecasModel> Pecas { get; set; }
        public DbSet<MaquinaModel> Maquina { get; set; }
        public DbSet<PecasPorMaquinaModel> PecasPorMaquina { get; set; }
        public DbSet<PecasPorMaquinaEOrdemModel> PecasPorOrdemServico { get; set; }

    }
}
