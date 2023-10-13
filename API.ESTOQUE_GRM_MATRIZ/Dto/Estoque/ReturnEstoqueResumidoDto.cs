using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Local;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;

namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class ReturnEstoqueResumidoDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public double Quantidade { get; set; }
        public bool Ativo { get; set; }
        public ReturnLocaleStorageResume LocalEstocagem { get; set; }
        public ReturnTypeMaterialResumeDto Tipo {  get; set; }
    }
}
