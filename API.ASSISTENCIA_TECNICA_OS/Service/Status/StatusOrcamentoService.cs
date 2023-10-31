using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Status;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Status
{
    public class StatusOrcamentoService : IStatusOrcamentoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public StatusOrcamentoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<object> ApontarAguardandoOrcamento(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId);

            var objApontamento = new UsuarioApontamentoInicioStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoInicioId = dto.UsuarioApontamentoId
            };
            _context.StatusOrcamento.Update(obj);
            await _context.SaveChangesAsync();

            return new object();
        }
        public async Task<object> ApontarOrcamentoFinalizado(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId);

            obj.UsuarioApontamentoInicio = new UsuarioApontamentoInicioStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoInicioId = dto.UsuarioApontamentoId
            };
            _context.StatusOrcamento.Update(obj);
            await _context.SaveChangesAsync();

            return new object();
        }
    }
}
