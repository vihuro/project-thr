using API.AUTH.Service.JWT;
using Microsoft.AspNetCore.Mvc;
using API.AUTH.Dto.user.Token;
using API.AUTH.Interface;

namespace API.AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IRefreshTokenService _service;

        public TokenController(IRefreshTokenService service)
        {
            _service = service;
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenDto>> RefreshToken(Guid id)
        {
            try
            {
                var token = await _service.RefresToken(id);
                return Ok(token);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
