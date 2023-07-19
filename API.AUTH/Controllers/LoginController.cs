using API.AUTH.Dto.Link;
using API.AUTH.Dto.user;
using API.AUTH.Dto.user.ReturnWithLink;
using API.AUTH.Dto.user.Token;
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
                        Link = new List<LinkDto> { CreateSelfLinkId(item.UsuarioId) }
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
        public async Task<ActionResult<DataListUsersDto>> GetById(Guid id)
        {
            try
            {
                var response = await _userService.GetById(id);
                var listLisk = CreateLinks(response.UsuarioId, response.Apelido);

                var data = new DataListUsersDto
                {
                    Link = listLisk,
                    User = response
                };

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("apelido/{apelido}")]
        public async Task<ActionResult<DataListUsersDto>> GetByNome(string apelido)
        {
            try
            {
                var response = await _userService.GetByUserName(apelido);
                var listLisk = CreateLinks(response.UsuarioId, response.Apelido);

                var data = new DataListUsersDto
                {
                    Link = listLisk,
                    User = response
                };

                return Ok(data);

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
        public async Task<ActionResult<DataListUsersDto>> Insert(RegisterUserDto dto)
        {
            try
            {
                var response = await _userService.Insert(dto);
                var listLisk = CreateLinks(response.UsuarioId, response.Apelido);

                var data = new DataListUsersDto
                {
                    Link = listLisk,
                    User = response
                };

                return Ok(data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("changePassword")]
        public async Task<ActionResult<DataListUsersDto>> ChangePassword(ChangePassword dto)
        {
            try
            {
                var response = await _userService.ChangePassword(dto);
                var listLisk = CreateLinks(response.UsuarioId, response.Apelido);

                var data = new DataListUsersDto
                {
                    Link = listLisk,
                    User = response
                };

                return Ok(data);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("changePasswordOrActive")]
        public async Task<ActionResult<DataListUsersDto>> ChangePasswordOrActive(ChangePasswordOrActive dto)
        {
            try
            {
                var response = await _userService.ChangePasswordOrActive(dto);
                var listLisk = CreateLinks(response.UsuarioId, response.Apelido);

                var data = new DataListUsersDto
                {
                    Link = listLisk,
                    User = response
                };

                return Ok(data);
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

        private List<LinkDto> CreateLinks(Guid id, string apelido)
        {
            var list = new List<LinkDto>
            {
                CreateGetAllLink(),
                CreateSelfLinkApelido(apelido),
                CreateSelfLinkId(id),
                CreateUpdatePasswordLink(id),
                CreateUpdatePasswordOrActiveLink(id),
                CreateDeleteLink(id)
            };


            return list;
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

        private LinkDto CreateSelfLinkApelido(string apelido)
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetByNome), new { apelido }),
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
        private LinkDto CreateGetAllLink()
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetAll)),
                Method = HttpMethod.Get.Method
            };
            return link;
        }

    }
}
