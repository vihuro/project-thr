using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento.Sugestao;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/sugestao")]
    public class SugestacaoController : ControllerBase
    {
        private readonly ISugestaoService _service;

        public SugestacaoController(ISugestaoService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<ReturnSugestaoDto>> InsertSugestao(InsertSugestaoDto dto)
        {
            try
            {
                var result = await _service.InsertSugestacao(dto);

                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnSugestaoDto>>> GetAll()
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
        public async Task<ActionResult> DeleteAll()
        {
            try
            {
                await _service.DeleteAll();

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("maquina/{maquinaId}")]
        public async Task<ActionResult<List<ReturnSugestaoDto>>> GetByMaquinaId(Guid maquinaId)
        {
            try
            {
                var result = await _service.GetByMaquinaId(maquinaId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{sugestaoId}")]
        public async Task<ActionResult<ReturnSugestaoDto>> GetById(int sugestaoId)
        {
            try
            {
                var result = await _service.GetById(sugestaoId);


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
