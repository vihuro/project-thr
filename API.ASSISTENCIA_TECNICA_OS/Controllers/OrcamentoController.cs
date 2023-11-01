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
        [HttpPost("aguardando-orcamento")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForAguardandoOrcamento(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForAguardandoOrcamento(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("aguardando-liberacao-orcamento")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForAguardandoLiberacaoOrcamento(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForAguardandoLiberacaoOrcamento(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("orcamento-recusado")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForOrcamentoRecusado(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForOrcamentoRecusado(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("aguardando-manutencao")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForAguardandoManutencao(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForAguardandoManutencao(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("manutencao-iniciada")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForManutencaoIniciada(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForManutencaoIniciada(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("manutencao-finalizada")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForManutencaoFinalizada(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForManutencaoFinalizada(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("limpeza-iniciada")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForLimpezaIniciada(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForLimpezaIniciada(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("finalizado")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusOrcamentoFinalizado(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusOrcamentoFinalizado(dto);
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
