using API.ASSISTENCIA_TECNICA_OS.DTO.Status;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/status")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<ReturnStatusDto>> Insert(InsertStatusDto dto)
        {
            try
            {
                var result = await _service.Insert(dto);
                return Created("",result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{userId}")]
        public async Task<ActionResult<List<ReturnStatusDto>>> InsertListStatus(Guid userId)
        {
            try
            {
                var result = await _service.InsertStatusList(userId);
                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnStatusDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
