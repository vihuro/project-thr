using API.AUTH.Models.Claims;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.AUTH.Models.User
{
    [Table("tab_user")]
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
        public List<ClaimsForUserModel> ClaimsForUser { get; set; }

    }
}
