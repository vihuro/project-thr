using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/assistencia-tecnica/maquinas/pecas")]
    public class PecasPorMaquinaController : ControllerBase
    {
        private readonly Context _context;

        public PecasPorMaquinaController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(PecasPorMaquinaModel dto)
        {
            try
            {
                var obj = new PecasPorMaquinaModel
                {
                    MaquinaId = dto.MaquinaId,
                    PecaId = dto.PecaId,
                };
                _context.PecasPorMaquina.Add(obj);
                await _context.SaveChangesAsync();
                return Created("", obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            try
            {
                var list = await _context.PecasPorMaquina.ToListAsync();
                _context.PecasPorMaquina.RemoveRange(list);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
