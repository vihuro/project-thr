using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas
{
    [Table("tab_maquina")]
    public class MaquinaModel
    {
        [Key]
        public Guid Id { get; set; }
        public string TipoMaquina { get; set; }
        public string NumeroSerie { get; set; }
        public bool Ativo { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UserModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UserModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public virtual MaquinaClienteModel MaquinaCliente { get; set; }
    }
}
