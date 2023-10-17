using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas
{
    [Table("tab_maquina")]
    public class MaquinaModel
    {
        public Guid Id { get; set; }
        [Required]
        public string CodigoMaquina { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3,
             ErrorMessage = "O tipo da máquina deve conter pelo menos 3 caracteres!")]
        public string DescricaoMaquina { get; set; }
        public string Unidade { get; set; }

        [Required]
        public bool Atribuida { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 4,
                     ErrorMessage = "O número de série tem que conter de 4 a 150 caracteres!")]
        public string NumeroSerie { get; set; }
        [Required]
        public bool Ativo { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UserModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UserModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public virtual MaquinaClienteModel MaquinaCliente { get; set; }
        public virtual List<PecasPorMaquinaModel> Pecas { get; set; }
    }
}
