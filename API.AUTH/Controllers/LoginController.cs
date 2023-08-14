using API.AUTH.Dto.user;
using API.AUTH.Dto.user.Token;
using API.AUTH.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.AUTH.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReturnListUserDto>>> GetAll()
        {
            try
            {
                var result = await _userService.GetAll();

                var response = new ReturnListUserDto
                {
                    TotalUsers = result.Count,
                    DataUsers = new List<ReturnUserDto>()
                };

                foreach (var item in result)
                {
                    response.DataUsers.Add(item);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnUserDto>> GetById(Guid id)
        {
            try
            {
                var response = await _userService.GetById(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("apelido/{apelido}")]
        public async Task<ActionResult<ReturnUserDto>> GetByNome(string apelido)
        {
            try
            {
                var response = await _userService.GetByUserName(apelido);

                return Ok(response);

            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TokenDto>> Login(LoginDto dto)
        {
            try
            {
                return Ok(await _userService.Login(dto));
            }
            catch (Exception ex)
            {
                if(ex.HResult == 401) return Unauthorized(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("created")]
        public async Task<ActionResult<ReturnUserDto>> Insert(RegisterUserDto dto)
        {
            try
            {
                var response = await _userService.Insert(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("changePassword")]
        public async Task<ActionResult<ReturnUserDto>> ChangePassword(ChangePassword dto)
        {
            try
            {
                var response = await _userService.ChangePassword(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("changePasswordOrActive")]
        public async Task<ActionResult<ReturnUserDto>> ChangePasswordOrActive(ChangePasswordOrActive dto)
        {
            try
            {
                var response = await _userService.ChangePasswordOrActive(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            try
            {
                return Ok(await _userService.DeleteUser(id));
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAll()
        {
            try
            {
                return Ok(await _userService.DeleteAll());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
