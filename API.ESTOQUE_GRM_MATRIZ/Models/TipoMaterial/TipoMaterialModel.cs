using API.ESTOQUE_GRM_MATRIZ.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ESTOQUE_GRM_MATRIZ.Models.TipoMaterial
{
    [Table("tab_tipo_matetial")]
    public class TipoMaterialModel
    {
        public Guid Id { get; set; }
        public string TipoMaterial { get; set; }
        public Guid UserRegisterId { get; set; }
        public virtual UserAuthModel UserRegister { get; set; }
        public DateTime DataTimeRegister { get; set; }
        public Guid UserChangeId { get; set; }
        public virtual UserAuthModel UserChange { get; set; }
        public DateTime DataTimeChange { get; set; }

    }
}
