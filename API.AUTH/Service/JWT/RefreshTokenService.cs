using API.AUTH.Dto.user.Token;
using API.AUTH.Interface;
using API.AUTH.Service.User;
using THR.auth.Service.ExceptionService;

namespace API.AUTH.Service.JWT
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly ICreateTokenService _createTokenService;
        private readonly IUserService _userService;

        public RefreshTokenService(ICreateTokenService createTokenService, 
                                    IUserService userService)
        {
            _createTokenService = createTokenService;
            _userService = userService;
        }

        public async Task<TokenDto> RefresToken(Guid id)
        {
            var user = await _userService.GetById(id);

            if (!user.Ativo) throw new CustomException("Usuário bloqueado!");
            var acessToken = _createTokenService.AccessToken(user);
            var refreshToken = _createTokenService.RefreshToken(user.UsuarioId);

            return new TokenDto
            {
                AccessToken = acessToken,
                RefreshToken = refreshToken,
            };
        }
    }
}
