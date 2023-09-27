using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/orcamento")]
    public class OrcamentoController : ControllerBase
    {
        private IOrcamentoService _service;

        public OrcamentoController(IOrcamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnOrcamentoDto>> Insert(InsertOrcamentoDto dto)
        {
            try
            {
                var result = await _service.InsertOrcamento(dto);

                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnOrcamentoResumidoDto>>> GetAll()
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
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnOrcamentoResumidoDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
