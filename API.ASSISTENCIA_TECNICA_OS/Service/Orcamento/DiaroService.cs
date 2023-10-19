using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Orcamento
{
    public class DiaroService : IDiarioService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;

        public DiaroService(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ReturnDiarioOrcamentoDto> InsertInformaca(InsertInformacaoDiarioDto dto)
        {
            var obj = _mapper.Map<DiarioOrcamentoModel>(dto);

            _context.Diario.Add(obj);
            await _context.SaveChangesAsync();

            return await GetByNumeroApontamento(obj.Id);
        }
        public async Task<ReturnDiarioOrcamentoDto> GetByNumeroApontamento(int numeroApontamento)
        {
            var obj = await _context.Diario
                .Include(u => u.UsuarioApontamento)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == numeroApontamento);

            var dto = _mapper.Map<ReturnDiarioOrcamentoDto>(obj);

            return dto;
        }
    }
}
