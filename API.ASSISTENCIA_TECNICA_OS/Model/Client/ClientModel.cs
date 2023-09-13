using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Client
{
    [Table("tab_client")]
    public class ClientModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome do cliente obrigatório!")]
        [StringLength(100)]
        public string Nome { get; set; }
        public string CodigoRadar { get; set; }
        [Required]
        [StringLength(20)]
        public string CEP { get; set; }
        [Required]
        [StringLength(4)]
        public string Estado { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        [StringLength(50)]
        public string Regiao { get;set; }
        [Required]
        [StringLength(100)]
        public string Rua { get; set; }
        [Required]
        public string NumeroEstabelecimento { get; set; }
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(15)]
        public string ContatoTelefone { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public virtual UserModel UsuarioCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public virtual UserModel UsuarioAlteracao { get; set; }
#nullable enable
        [StringLength(50)]
        public string? Complemento { get; set; }
        [StringLength(50)]
        public string? NomeContatoClient { get; set; }
        public virtual List<MaquinaClienteModel>? Maquinas { get; set; }

    }
}
