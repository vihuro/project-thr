using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas.PecasNoOrcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/orcamento/pecas")]
    public class PecasNoOrcamentoController : ControllerBase
    {
        private readonly IPecasNoOrcamentoService _service;

        public PecasNoOrcamentoController(IPecasNoOrcamentoService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<ReturnPecasOrcamentoDto>> InsertPecasNoOrcamento(InsertPecasNoOrcamentoDto dto)
        {
            try
            {
                var result = await _service.InsertPecasNoOrcamento(dto);
                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePecasNoOrcamento(DeletePecaNoOrcamentoDto dto)
        {
            try
            {
                var result = await _service.DeletePecaNoOrcamento(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
