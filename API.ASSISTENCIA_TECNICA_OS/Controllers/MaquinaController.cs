using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/maquina")]
    public class MaquinaController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MaquinaController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(InsertMaquinaDto dto)
        {
            try
            {
                var obj = _mapper.Map<MaquinaModel>(dto);

                _context.Maquina.Add(obj);
                await _context.SaveChangesAsync();

                var result = await _context.Maquina
                    .Include(p => p.Pecas)
                        .ThenInclude(p => p.Peca)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == obj.Id);
                //VERIFICAR

                var mapper = _mapper.Map<ReturnMaquinaComPecasDto>(result);



                return Created("", mapper);
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
                var list = await _context.Maquina
                    .Include(p => p.Pecas)
                        .ThenInclude(p => p.Peca)
                    .AsNoTracking()
                    .ToListAsync();

                var result = _mapper.Map<List<ReturnMaquinaComPecasDto>>(list);

                return Ok(result);
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
