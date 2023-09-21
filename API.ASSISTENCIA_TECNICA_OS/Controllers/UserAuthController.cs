using API.ASSISTENCIA_TECNICA_OS.DTO.User;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [Route("api/v1/user-auth")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserService _service;

        public UserAuthController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<string>> VerifyAll()
        {
            try
            {
                var result = await _service.VerifyUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
