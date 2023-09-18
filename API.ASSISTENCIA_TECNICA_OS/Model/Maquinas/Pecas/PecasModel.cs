using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas
{
    [Table("tab_pecas")]
    public class PecasModel
    {
        [Key]
        public Guid Id { get; set; }
        public string CodigoRadar { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UserModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UserModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
#nullable enable

        public List<string>? EnderecoImagem { get; set; }
    }
}
