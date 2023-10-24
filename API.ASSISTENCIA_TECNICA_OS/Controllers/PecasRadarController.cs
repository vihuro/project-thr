using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Service.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/relatorio-radar")]
    public class PecasRadarController : ControllerBase
    {
        private readonly IPecasRadarService _servicer;

        public PecasRadarController(IPecasRadarService servicer)
        {
            _servicer = servicer;
        }

        [HttpGet]
        public async Task<ActionResult<List<PecasRadarDto>>> GetAll()
        {
            try
            {
                var result = await _servicer.GetAll();

                var resultInService = new
                {
                    total = result.Count,
                    data = result
                };

                return Ok(resultInService);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("pecas")]
        public async Task<ActionResult<List<PecasRadarDto>>> GetPecas()
        {
            try
            {
                var result = await _servicer.GetPecas();

                var resultInService = new
                {
                    total = result.Count,
                    data = result
                };

                return Ok(resultInService);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("maquinas")]
        public async Task<ActionResult<List<PecasRadarDto>>> GetMaquinasEAparelhos()
        {
            try
            {
                var result = await _servicer.GetMaquinaEAperelhos();

                var resultInService = new
                {
                    total = result.Count,
                    data = result
                };

                return Ok(resultInService);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<List<PecasModel>>> InsertPecas([FromBody] Guid userId)
        {
            try
            {
                var resutl = await _servicer.InsertPecas(userId);
                return Ok(resutl);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
