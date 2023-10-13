using API.ESTOQUE_GRM_MATRIZ.Models.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ESTOQUE_GRM_MATRIZ.Models.Substituto
{
    [Table("tab_substitutos")]
    public class SubstitutoModel
    {
        public int Id { get; set; }
        public int MaterialEstoqueId { get; set; }
        public virtual EstoqueModel MaterialEstoque { get; set; }
        public int SubstitutoId { get; set; }
        public virtual EstoqueModel Substituto { get; set; }
        public Guid UsuarioCadatroId { get; set; }
        public virtual UserAuthModel UsuarioCadatro { get; set; }
        public DateTime DataHoraCadatro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UserAuthModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }

    }
}
