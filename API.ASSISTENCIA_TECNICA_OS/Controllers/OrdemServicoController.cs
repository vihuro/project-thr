using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using API.ASSISTENCIA_TECNICA_OS.DTO.OrdemServico;
using API.ASSISTENCIA_TECNICA_OS.Model.OrdemServico;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;

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
        public async Task<ActionResult> Insert(InsertOrdemDto dto)
        {
            try
            {
                /*var obj = new OrdemServicoModel
                {
                    Descricao = dto.Descricao,
                    Status = "ABERTO",
                };*/
                var obj = _mapper.Map<OrdemServicoModel>(dto);

                if(dto.Maquinas.Count > 0)
                {
                    obj.MaquinaPorOs = new List<PecasPorMaquinaEOrdemModel>();
                    foreach(var item in dto.Maquinas)
                    {
                        var maquina = await _context.Maquina
                            .Include(p => p.Pecas)
                                .ThenInclude(p => p.Peca)
                            .FirstOrDefaultAsync(m => m.Id == item.IdMaquina);
                        if(maquina.Pecas.Count > 0)
                        {
                            foreach(var itemPeca in maquina.Pecas)
                            {
                                obj.MaquinaPorOs.Add(new PecasPorMaquinaEOrdemModel
                                {
                                    Conserto = false,
                                    MaquinaId = maquina.Id,
                                    PecaId = itemPeca.PecaId,
                                    Troca = false,
                                    
                                });
                            }
                        }
                    }
                }

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
                var obj = new PecasPorMaquinaEOrdemModel
                {
                    MaquinaId = idMaquina,
                    OrdemServicoId = idOs
                };
                //_context.MaquinaPorOs.Add(obj);
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
                     .Include(p => p.MaquinaPorOs)
                        .ThenInclude(p => p.Peca)

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
