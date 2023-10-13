using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Local;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;

namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class ReturnEstoqueDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public string Unidade { get; set; }
        public bool Ativo { get; set; }
        public double Preco { get; set; }
        public DateTime DataFabricao { get; set; }
        public UsertDateTime Cadastro { get; set; }
        public UsertDateTime Alteracao { get; set; }
        public ReturnLocaleStorageResume LocalEstocagem { get; set; }
        public ReturnTypeMaterialResumeDto TipoMaterial { get; set; }
        public List<ReturnSubstitutosResumeDto> Substitutos { get; set; }

        public string ClienteUltimaCompra1 { get; set; }
        public string CodigoClienteUltimaCompra1 { get; set; }
        public string ClienteUltimaCompra2 { get; set; }
        public string CodigoClienteUltimaCompra2 { get; set; }
        public string ClienteUltimaCompra3 { get; set; }
        public string CodigoClienteUltimaCompra3 { get; set; }
    }
}
