using API.AUTH.Dto.user;
using API.AUTH.Dto.user.ReturnWithLink;
using API.AUTH.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.AUTH.Controllers
{
    [Route("api/[controller]")]
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

                var listOfUser = new ReturnListUserDto
                {
                    TotalUsers = result.Count
                };

                foreach (var item in result)
                {
                    listOfUser.DataUsers.Add(new DataListUsersDto
                    {
                        User = item,
                        Link = CreateSelfLinkGetAll(item.UsuarioId)
                    });
                }

                return Ok(listOfUser);
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
                var user = await _userService.GetById(id);
                if (user == null)
                    return NotFound();

                var response = new
                {
                    user,
                    links = new List<LinkDto>
                    {
                        CreateSelfLinkApelido(user.Apelido),
                        CreateUpdatePasswordLink(id),
                        CreateDeleteLink(id)
                    }
                };
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
                var user = await _userService.GetByUserName(apelido);
                var response = new
                {
                    user,
                    links = new List<LinkDto>
                    {
                        CreateSelfLinkId(user.UsuarioId),
                        CreateUpdatePasswordLink(user.UsuarioId),
                        CreateUpdatePasswordOrActiveLink(user.UsuarioId),
                        CreateDeleteLink(user.UsuarioId)
                    }
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            try
            {
                return Ok(await _userService.Login(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("created")]
        public async Task<ActionResult<ReturnUserDto>> Insert(RegisterUserDto dto)
        {
            try
            {
                var obj = await _userService.Insert(dto);
                var response = new
                {
                    obj,
                    links = new List<LinkDto>
                    {
                        CreateSelfLinkId(obj.UsuarioId),
                        CreateUpdatePasswordLink(obj.UsuarioId),
                        CreateUpdatePasswordOrActiveLink(obj.UsuarioId),
                        CreateDeleteLink(obj.UsuarioId)
                    }

                };
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
                return Ok(await _userService.ChangePassword(dto));
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
                return Ok(await _userService.ChangePasswordOrActive(dto));
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

        private LinkDto CreateSelfLinkGetAll(Guid id)
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetById), new { id }),
                Method = HttpMethod.Get.Method
            };
            return link;
        }

        private LinkDto CreateSelfLinkApelido(string id)
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetById), new { id }),
                Method = HttpMethod.Get.Method
            };
            return link;
        }

        private LinkDto CreateSelfLinkId(Guid id)
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetById), new { id }),
                Method = HttpMethod.Get.Method
            };
            return link;
        }

        private LinkDto CreateUpdatePasswordLink(Guid id)
        {
            return new LinkDto
            {
                Rel = "updatePassword",
                Href = Url.Action(nameof(ChangePassword)),
                Method = HttpMethod.Put.Method
            };
        }
        private LinkDto CreateUpdatePasswordOrActiveLink(Guid id)
        {
            return new LinkDto
            {
                Rel = "updatePasswordOrActive",
                Href = Url.Action(nameof(ChangePasswordOrActive)),
                Method = HttpMethod.Put.Method
            };
        }

        private LinkDto CreateDeleteLink(Guid id)
        {
            return new LinkDto
            {
                Rel = "delete",
                Href = Url.Action(nameof(DeleteUser), new { id }),
                Method = HttpMethod.Delete.Method
            };
        }

    }
}
