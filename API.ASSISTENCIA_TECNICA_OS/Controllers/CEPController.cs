using API.ASSISTENCIA_TECNICA_OS.DTO.CEP;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/cep")]
    public class CEPController : ControllerBase
    {
        private readonly ICEPService _service;

        public CEPController(ICEPService service)
        {
            _service = service;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<CepDto>> Get(int cep)
        {
            try
            {
                var response = await _service.Get(cep);

                return Ok(response);

            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
