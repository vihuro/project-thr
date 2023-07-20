using System.ComponentModel.DataAnnotations.Schema;

namespace API.ESTOQUE_GRM_MATRIZ.Models.User
{
    [Table("tab_user_auth")]
    public class UserAuthModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
    }
}
