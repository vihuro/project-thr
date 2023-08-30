using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using API.ASSISTENCIA_TECNICA_OS.DTO.OrdemServico;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/ordem-servico")]
    public class OrdemServicoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public OrdemServicoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Insert(OSModel dto)
        {
            try
            {
                var obj = new OSModel()
                {
                    Descricao = dto.Descricao,
                    Status = "ABERTO"
                };
                _context.Os.Add(obj);
                await _context.SaveChangesAsync();

                return Ok(obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult> InsertMaquina(int idOs, Guid idMaquina)
        {
            try
            {
                var obj = new MaquinasPorOsModel
                {
                    MaquinaId = idMaquina,
                    OsId = idOs
                };
                _context.MaquinaPorOs.Add(obj);
                await _context.SaveChangesAsync();
                return Ok(obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult >GetAll() 
        {
            try
            {

                var list =await  _context.Os
                    .Include(m => m.MaquinaPorOs)
                        .ThenInclude(m => m.Maquina)
                    .AsNoTracking()
                    .ToListAsync();

                var dto = _mapper.Map<List<ReturnOrdemDto>>(list);

                return Ok(dto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
