using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Local;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;

namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto
{
    public class ReturnSubstitutoDto
    {
        public Guid Id { get; set; }
        public Guid CodigoId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public decimal Quantidade { get; set; }
        public ReturnEstoqueResumidoDto Substituto { get; set; }
        public ReturnTypeMaterialResumeDto Tipo { get; set; }
        public ReturnLocaleStorageResume LocalEstocagem { get; set; }
        public UsertDateTime Cadastro { get; set; }
        public UsertDateTime Alteracao { get; set; }
    }
}
