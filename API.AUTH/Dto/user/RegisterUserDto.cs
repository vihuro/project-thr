using API.AUTH.Dto.Claims;
using API.AUTH.Models.Claims;

namespace API.AUTH.Dto.user
{

    public class RegisterUserDto
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Senha { get; set; }
#nullable enable
        public List<RegisterUserClaimsDto>? Claims { get; set; }
    }
}
