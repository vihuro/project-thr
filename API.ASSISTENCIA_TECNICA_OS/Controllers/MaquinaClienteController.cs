using API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/maquina/cliente")]
    public class MaquinaClienteController : ControllerBase
    {
        private readonly IMaquinaClienteService _service;

        public MaquinaClienteController(IMaquinaClienteService service)
        {
            _service = service;
        }
        [HttpPut]
        public async Task<ActionResult<ReturnMaquinaClienteDto>> UpdateMaquinaInClient(InsertMaquinaInClientDto dto)
        {
            try
            {
                var restult = await _service.UpdateMaquinaInCliente(dto);
                return Ok(restult);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("emprestimos")]
        public async Task<ActionResult<List<ReturnMaquinaClienteDto>>> GetMaquinasEmEmprestimos()
        {
            try
            {
                var result = await _service.GetMaquinasEmEmprestimo();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
