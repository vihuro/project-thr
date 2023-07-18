using API.AUTH.Dto.user.Token;

namespace API.AUTH.Interface
{
    public interface IRefreshTokenService
    {
        Task<TokenDto> RefresToken(Guid id);
    }
}
