using API.ASSISTENCIA_TECNICA_OS.DTO.Client;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/cliente")]
    public class ClientController : ControllerBase
    {
        private readonly IClientInteService _service;

        public ClientController(IClientInteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnClientDto>> Insert(InsertClientDto dto)
        {
            try
            {
                var result = await _service.Insert(dto);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnClientDto>>> GetAll()
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
    }
}
