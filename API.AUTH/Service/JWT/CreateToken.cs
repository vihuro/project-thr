using API.AUTH.Dto.user;
using API.AUTH.Dto.user.Token;
using API.AUTH.Interface;
using API.AUTH.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.AUTH.Service.JWT
{
    public class CreateToken : ICreateTokenService
    {
        private readonly AppSettings _settings;


        public CreateToken(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public string RefreshToken(Guid idUser)
        {
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenHeader = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHeader.CreateToken(tokenDescriptor);

            return tokenHeader.WriteToken(token);
        }

        public  string AccessToken(ReturnUserDto dto)
        {
            var tokenHeader = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor();
            var uniqueName = new Claim(ClaimTypes.Name, dto.Apelido);
            var name = new Claim("Nome", dto.Nome);
            var identityName = new Claim("idUser", dto.UsuarioId.ToString());
            var active = new Claim("active", dto.Ativo.ToString());
            var claims = new List<Claim>();

            foreach (var item in dto.Claims)
            {
                claims.Add(new Claim(item.ClaimName, item.ClaimValue));
            }
            claims.Add(uniqueName);
            claims.Add(name);
            claims.Add(active);
            claims.Add(identityName);
            tokenDescriptor.Subject = new ClaimsIdentity(claims);
            var expiration = DateTime.UtcNow.AddHours(1);
            tokenDescriptor.Expires = expiration;
            tokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var token = tokenHeader.CreateToken(tokenDescriptor);

            return tokenHeader.WriteToken(token);
        }

        public TokenDto Token(ReturnUserDto dto)
        {
            var accessToken = AccessToken(dto);
            var refreshToken = RefreshToken(dto.UsuarioId);

            var Token = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return Token;

        }

    }
}
