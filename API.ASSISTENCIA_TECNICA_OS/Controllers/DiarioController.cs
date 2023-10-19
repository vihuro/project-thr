using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/orcamento/diario")]
    public class DiarioController : ControllerBase
    {
        private readonly IDiarioService _service;

        public DiarioController(IDiarioService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<ReturnDiarioOrcamentoDto>> Insert(InsertInformacaoDiarioDto dto)
        {
            try
            {
                var result = await _service.InsertInformaca(dto);

                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
