using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/maquina")]
    public class MaquinaController: ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MaquinaController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(MaquinaModel dto)
        {
            try
            {
                var obj = new MaquinaModel
                {
                    Ativo = true,
                    TipoMaquina = dto.TipoMaquina,
                };
                _context.Maquina.Add(obj);
                await _context.SaveChangesAsync();
                return Created("", obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var list = await _context.Maquina.ToListAsync();

                return Ok(list);
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
                var list = await _context.Maquina.ToListAsync();
                _context.Maquina.RemoveRange(list);
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
