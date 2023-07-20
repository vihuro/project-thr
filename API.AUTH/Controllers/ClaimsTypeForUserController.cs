using API.AUTH.Dto.Claims;
using API.AUTH.Dto.ClaimsForUser;
using API.AUTH.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsTypeForUserController : ControllerBase
    {
        private readonly IClaimsForUserService _claimsForUserService;

        public ClaimsTypeForUserController(IClaimsForUserService claimsForUserService)
        {
            _claimsForUserService = claimsForUserService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnClaimsForUserDto>>> GetAll()
        {
            try
            {
                var result = await _claimsForUserService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnClaimsForUser>>> GetById(Guid id)
        {
            try
            {
                var result = await _claimsForUserService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ReturnClaimsForUser>>> GetByUserId(Guid iduserId)
        {
            try
            {
                var result = await _claimsForUserService.GetByUserId(iduserId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("{claimId}")]
        public async Task<ActionResult<List<ReturnClaimsForUser>>> GetByClaimId(Guid claimId)
        {
            try
            {
                var result = await _claimsForUserService.GetByClaimId(claimId);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult<ReturnClaimsForUserDto>> Insert(InsertClaimsForUserDto dto)
        {
            try
            {
                var result = await _claimsForUserService.Insert(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpDelete("delete-all")]
        public async Task<ActionResult<bool>> DeleteAll()
        {
            try
            {
                var result = await _claimsForUserService.DeleteAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
