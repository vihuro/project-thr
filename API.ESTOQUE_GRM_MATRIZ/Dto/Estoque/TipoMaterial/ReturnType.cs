using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;

namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial
{
    public class ReturnType
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public UsertDateTime Cadastro { get; set; }
        public UsertDateTime Alteracao { get; set; }
    }
}
