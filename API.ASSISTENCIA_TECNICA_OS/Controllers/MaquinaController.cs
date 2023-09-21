using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/maquina")]
    public class MaquinaController : ControllerBase
    {
        private readonly IMaquinaService _service;

        public MaquinaController(IMaquinaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnMaquinaComPecasDto>> Insert(InsertMaquinaDto dto)
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
        [HttpPut]
        public async Task<ActionResult<ReturnMaquinaComPecasDto>> Update(UpdateMaquinaDto dto)
        {
            try
            {
                var result = await _service.UpdateMaquina(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnMaquinaComPecasDto>>> GetAll()
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
        [HttpGet("sem-atribuicao")]
        public async Task<ActionResult<List<ReturnMaquinaComPecasDto>>> GetBySemAtribuicao()
        {
            try
            {
                var result = await _service.GetBySemAtribuicao();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete()
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
