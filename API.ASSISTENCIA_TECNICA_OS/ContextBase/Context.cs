using API.ASSISTENCIA_TECNICA_OS.Model.Client;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Model.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.ContextBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        //cliente
        public DbSet<ClientModel> Cliente { get; set; }
        //peças
        public DbSet<PecasMaquinaOrcamentoModel> PecasPorOrdemServico { get; set; }
        public DbSet<PecasModel> Pecas { get; set; }
        public DbSet<PecasPorMaquinaModel> PecasPorMaquina { get; set; }
        //maquina
        public DbSet<MaquinaClienteModel> MaquinaCliente { get; set; }
        public DbSet<MaquinaModel> Maquina { get; set; }
        
        //orçamento
        public DbSet<OrcamentoModel> Orcamento { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<StatusOrcamentoModel> StatusOrcamento { get; set; }
        public DbSet<UsuarioApontamentoInicioStatusModel> UsuarioApontamentoInicioStatus { get; set; }
        public DbSet<UsuarioApontamentoFimStatusModel> UsuarioApotamentoFimStatus { get; set; }
        public DbSet<SugestacaoManutencaoModel> Sugestao { get; set; }
        public DbSet<TecnicoOrcamentoModel> TecnicoOrcamento { get; set; }
        public DbSet<TecnicoManutencaoModel> TecnicoManutencao { get; set; }
        public DbSet<DiarioOrcamentoModel> Diario { get; set; }
        //tecnico
        public DbSet<TecnicoModel> Tecnico { get; set; }
        //user
        public DbSet<UserModel> User { get; set; }

    }
}
