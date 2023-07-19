using API.AUTH.Dto.Claims;
using API.AUTH.Dto.Claims.ReturnWithLink;
using API.AUTH.Dto.Link;
using API.AUTH.Dto.user;
using API.AUTH.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsTypeController : ControllerBase
    {
        private readonly IClaimsTypeService _service;

        public ClaimsTypeController(IClaimsTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ReturnTypeClaimsLinkDto>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                var link = new ReturnTypeClaimsLinkDto()
                {
                    TotalClaims = result.Count
                };

                foreach(var item in result)
                {
                    link.DataClaims.Add(new DataListClaimsTypeDto()
                    {
                        Claim = item,
                        Links = new List<LinkDto>()
                        {
                            CreateSelfLinkClaimId(item.ClaimId)
                        }
                    });
                }

                return Ok(link);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<ReturnTypeClaimsLinkDto>> GetById(Guid id)
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
        public async Task<ActionResult<ReturnTypeClaimsLinkDto>> GetByName(string claimName)
        {
            try
            {
                var result = await _service.GetByName(claimName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet("value/{claimValue}")]
        public async Task<ActionResult<ReturnTypeClaimsLinkDto>> GetByValue(string claimValue)
        {
            try
            {
                var result = await _service.GetByValue(claimValue);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet("value-name/{claimValue},{claimName}")]
        public async Task<ActionResult<ReturnTypeClaimsLinkDto>> GetByValueAndName(string claimValue, string claimName)
        {
            try
            {
                var result = await _service.GetByValueAndName(claimValue, claimName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<DataListClaimsTypeDto>> Insert(RegisterClaimDto dto)
        {
            try
            {
                var result = await _service.Insert(dto);

                var links = new DataListClaimsTypeDto
                {
                    Claim = result,
                    Links = CreateLinks(result.ClaimId,result.ClaimName,result.ClaimValue)
                };

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<ReturnTypeClaimsLinkDto>> Update()
        {
            try
            {
                return Ok(new ReturnTypeClaimsLinkDto());
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        private List<LinkDto> CreateLinks(Guid id, string name, string value)
        {
            var list = new List<LinkDto>
            {
                CreateGetAllLink(),
                CreateSelfLinkClaimName(name),
                CreateSelfLinkClaimValue(value),
                CreateSelfLinkClaimValueAndName(name, value),
                CreateSelfLinkClaimId(id),
                CreateUpdateLinkClaim(id),
            };


            return list;
        }

        private LinkDto CreateSelfLinkGetAll()
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetAll)),
                Method = HttpMethod.Get.Method
            };
            return link;
        }
        private LinkDto CreateSelfLinkClaimName(string name)
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetByName), new { name }),
                Method = HttpMethod.Get.Method
            };
            return link;
        }
        private LinkDto CreateSelfLinkClaimValue(string value)
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetByValue), new { value }),
                Method = HttpMethod.Get.Method
            };
            return link;
        }
        private LinkDto CreateSelfLinkClaimValueAndName(string value, string name)
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetByValueAndName), new { value,name }),
                Method = HttpMethod.Get.Method
            };
            return link;
        }
        private LinkDto CreateSelfLinkClaimId(Guid id)
        {
            var link = new LinkDto
            {
                Rel = "self",
                Href = Url.Action(nameof(GetAll), new { id}),
                Method = HttpMethod.Get.Method
            };
            return link;
        }
        private LinkDto CreateUpdateLinkClaim(Guid id)
        {
            return new LinkDto
            {
                Rel = "update",
                Href = Url.Action(nameof(Update)),
                Method = HttpMethod.Put.Method
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
