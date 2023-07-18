using API.AUTH.Dto.user;
using API.AUTH.Dto.user.Token;

namespace API.AUTH.Interface
{
    public interface ICreateTokenService
    {
        TokenDto Token(ReturnUserDto dto);
        string RefreshToken(Guid idUser);
        string AccessToken(ReturnUserDto dto);
    }
}
