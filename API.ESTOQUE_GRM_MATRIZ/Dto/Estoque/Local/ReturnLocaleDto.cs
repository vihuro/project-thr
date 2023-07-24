using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;

namespace API.ESTOQUE_GRM_MATRIZ.Dto.Estoque
{
    public class ReturnLocaleDto
    {
        public Guid Id { get; set; }
        public string Local { get;set; }
        public bool Ativo { get; set; }
        public UsertDateTime Cadastro {get; set; }
        public UsertDateTime Alteracao { get; set; }
    }
}
