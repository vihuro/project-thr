using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model.User
{
    [Table("tab_user")]
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
    }
}
