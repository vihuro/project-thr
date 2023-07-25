using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;

namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class InsertEstoqueDto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public Guid TipoMaterialId { get; set; }
        public string Unidade { get; set; }
#nullable enable
        public List<InsertEstoqueSubstitutoDto>? Substitutos { get; set; }
        public Guid LocalEstoqueId { get; set; }
        public decimal Quantidade { get; set; }
        public Guid UsuarioId { get; set; }

    }
}
