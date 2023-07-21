namespace API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth
{
    public class UserDto
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool Ativo { get; set; }
    }
}
