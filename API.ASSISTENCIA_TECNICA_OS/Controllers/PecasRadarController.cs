using API.ASSISTENCIA_TECNICA_OS.DTO;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Service.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/pecas/radar")]
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

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
