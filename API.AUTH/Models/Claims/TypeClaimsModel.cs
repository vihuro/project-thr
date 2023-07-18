using API.AUTH.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.AUTH.Models.Claims
{
    [Table("tab_typeClaims")]
    public class TypeClaimsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime DataHoraCadatro { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UserModel UsuarioCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UserModel UsuarioAlteracao { get; set; }

    }
}
