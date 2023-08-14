using API.AUTH.Dto.Claims;
using API.AUTH.Dto.Claims.ReturnWithLink;
using API.AUTH.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.AUTH.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClaimsTypeController : ControllerBase
    {
        private readonly IClaimsTypeService _service;

        public ClaimsTypeController(IClaimsTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ReturnTypeListClaimsDto>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                var response = new ReturnTypeListClaimsDto()
                {
                    TotalClaims = result.Count,
                    DataClaims = new List<ReturnTypeClaimsDto>()
                };

                foreach (var item in result)
                {
                    response.DataClaims.Add(item);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<ReturnTypeClaimsDto>> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet("name/{claimName}")]
        public async Task<ActionResult<ReturnTypeListClaimsDto>> GetByName(string claimName)
        {
            try
            {
                var result = await _service.GetByName(claimName);
                var links = new ReturnTypeListClaimsDto
                {
                    TotalClaims = result.Count,
                    DataClaims = new List<ReturnTypeClaimsDto>()
                };
                foreach (var item in result)
                {
                    links.DataClaims.Add(item);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet("value/{claimValue}")]
        public async Task<ActionResult<ReturnTypeListClaimsDto>> GetByValue(string claimValue)
        {
            try
            {
                var result = await _service.GetByValue(claimValue);
                var response = new ReturnTypeListClaimsDto
                {
                    TotalClaims = result.Count,
                    DataClaims = new List<ReturnTypeClaimsDto>()
                };
                foreach (var item in result)
                {
                    response.DataClaims.Add(item);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet("value-name/{claimValue},{claimName}")]
        public async Task<ActionResult<ReturnTypeClaimsDto>> GetByValueAndName(string claimValue, string claimName)
        {
            try
            {
                var result = await _service.GetByValueAndName(claimValue, claimName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<ReturnTypeClaimsDto>> Insert(RegisterClaimDto dto)
        {
            try
            {
                var result = await _service.Insert(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<ReturnTypeListClaimsDto>> Update(RegisterClaimDto dto)
        {
            try
            {
                return Ok(await _service.Update(dto));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAll()
        {
            try
            {
                var result = await _service.DeleteAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteById(Guid id)
        {
            try
            {
                var restul = await _service.DeleteById(id);

                return Ok(restul);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
       
    }
}
