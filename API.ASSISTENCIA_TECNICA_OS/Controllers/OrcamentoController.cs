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
        [HttpPut("insert-tecnico-orcamento")]
        public async Task<ActionResult> UpdateTecnicoNoOrcamento(UpdateTecnicoNoOrcamentoOuNaManutencaoDto dto)
        {
            try
            {
                var result = await _service.UpdateTecnicoNoOrcamento(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {

                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("insert-tecnico-manutencao")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateTecnicoNaManutencao(UpdateTecnicoNaManutencaoDto dto)
        {
            try
            {
                var result = await _service.UpdateTecnicoNaManutencao(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {

                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("insert-nota-radar")]
        public async Task<ActionResult<ReturnOrcamentoDto>> InsertNotaRadarNoOrcamento(InsertNumeroNotaRadarDto dto)
        {
            try
            {
                var result = await _service.InsertNumeroNotaRadar(dto);

                return Ok(result);
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
        [HttpGet("bi")]
        public async Task<ActionResult<List<ReturnOrcamentoDto>>> GetByBI()
        {
            try
            {
                var result = await _service.GetByBI();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnOrcamentoDto>>> GetById(int id)
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
        [HttpGet("numero-serie/{numeroSerie}")]
        public async Task<ActionResult<List<ReturnOrcamentoDto>>> GetByNumeroSerieMaquina(string numeroSerie)
        {
            try
            {
                var result = await _service.GetByNumeroSerieMaquina(numeroSerie);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("orcamento-iniciado")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForOrcando(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdatestatusForOrcando(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {

                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("aguardando-liberacao-orcamento")]
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
        [HttpPut("orcamento-recusado")]
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
        [HttpPut("aguardando-separacao-pecas")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForAguardandoSeparacaoPecas(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForAguardandoSeparacaoPecas(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("separacao-pecas-finalizada")]
        public async Task<ActionResult<ReturnOrcamentoDto>> UpdateStatusForSeparacaoPecasFinalizada(UpdateStatusOnBudgetDto dto)
        {
            try
            {
                var result = await _service.UpdateStatusForSeparacaoPecasFinalizada(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("manutencao-iniciada")]
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
        [HttpPut("manutencao-finalizada")]
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
        [HttpPut("limpeza-iniciada")]
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
        [HttpPut("finalizado")]
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
