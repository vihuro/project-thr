using API.ASSISTENCIA_TECNICA_OS.Model.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ASSISTENCIA_TECNICA_OS.Model
{
    [Table("tab_tecnico")]
    public class TecnicoModel
    {
        public Guid TecnicoId { get; set; }
        public Guid UsuarioId {  get; set; }
        public virtual UserModel Usuario { get; set; }
    }
}
