using API.ESTOQUE_GRM_MATRIZ.Models.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Models.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.ESTOQUE_GRM_MATRIZ.Models.Estoque
{
    [Table("tab_estoque")]
    public class EstoqueModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public Guid? TipoMaterialId { get; set; }
        public double Preco { get; set; }
        public DateTime DataFabricacao { get; set; }
        public bool Ativo { get; set; }
        public virtual TipoMaterialModel TipoMaterial { get; set; }
        public string Unidade { get; set; }
        public virtual List<SubstitutoModel> Substituos { get; set; }
        public Guid? LocalArmazenagemId { get; set; }
        public virtual LocalArmazenagemModel LocalArmazenagem { get; set; }
        public Guid UsuarioCadastroId { get; set; }
        public virtual UserAuthModel UsuarioCadastro { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public Guid UsuarioAlteracaoId { get; set; }
        public virtual UserAuthModel UsuarioAlteracao { get; set; }
        public DateTime DataHoraAlteracao { get; set; }

    }
}
