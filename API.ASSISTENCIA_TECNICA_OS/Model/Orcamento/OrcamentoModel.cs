using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Orcamento
{
    [Table("tab_orcamento")]
    public class OrcamentoModel
    {
        public int Id { get; set; }
        public string DescricaoServico { get; set; }
        public double ValorOrcamento { get; set; }
        public bool Externo { get; set; }
        public StatusSituacaoModel Status { get; set; }
        public virtual List<StatusOrcamentoModel> StatusOrcamento { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UserModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UserModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public Guid MaquinaId { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
        public Guid MaquinaClienteId { get; set; }
        public virtual TecnicoOrcamentoModel TecnicoOrcamento { get; set; }
        public virtual TecnicoManutencaoModel TecnicoManutenco { get; set; }
        public virtual MaquinaClienteModel MaquinaCliente { get; set; }
        public virtual List<PecasMaquinaOrcamentoModel> Pecas { get; set; }
        public virtual List<DiarioOrcamentoModel> Diario { get; set; }
    }
    public enum StatusSituacaoModel
    {
        AGUARDANDO_ATRIBUICAO = 0,
        AGUARDANDO_ORCAMENTO = 1,
        ORCANDO = 2,
        AGUARDANDO_LIBERACAO_ORCAMENTO = 3,
        AGUARDANDO_MANUTENCAO = 4,
        MANUTENCAO_INICIADA = 5,
        AGUARDANDO_PECAS = 6,
        PECAS_SEPARADAS = 7,
        MANUTENCAO_FINALIZADA = 8,
        LIMPEZA = 9,
        FINALIZADO = 10
    }
}
