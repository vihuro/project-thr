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
        public async Task<ActionResult<List<ReturnOrcamentoDto>>> GetAll()
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
