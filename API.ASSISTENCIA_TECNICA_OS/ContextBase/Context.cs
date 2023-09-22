using API.ASSISTENCIA_TECNICA_OS.Model.Client;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.ContextBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<MaquinaClienteModel> MaquinaCliente { get; set; }
        public DbSet<ClientModel> Cliente { get; set; }

        public DbSet<UserModel> User { get; set; }
        public DbSet<OrcamentoModel> Orcamento { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<StatusOrcamentoModel> StatusOrcamento { get; set; }
        public DbSet<PecasModel> Pecas { get; set; }
        public DbSet<MaquinaModel> Maquina { get; set; }
        public DbSet<PecasPorMaquinaModel> PecasPorMaquina { get; set; }
        public DbSet<PecasMaquinaOrcamentoModel> PecasPorOrdemServico { get; set; }

    }
}
