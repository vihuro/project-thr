using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
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
        public virtual List<StatusOrcamentoModel> Status { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UserModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UserModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public Guid MaquinaId { get; set; }
        public virtual MaquinaModel Maquina { get; set; }
        public Guid MaquinaClienteId { get; set; }
        public virtual MaquinaClienteModel MaquinaCliente { get; set; }
        public virtual List<PecasMaquinaOrcamentoModel> Pecas { get; set; }
    }
}
