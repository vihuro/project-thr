using API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly ITecnicoService _service;

        public TecnicoController(ITecnicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReturnTecnicoDto>>> GetAll()
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
        [HttpPost]
        public async Task<ActionResult<ReturnTecnicoDto>> InsertTecnico(InsertTecnicoDto dto)
        {
            try
            {
                var result = await _service.InsertTecnico(dto);
                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
