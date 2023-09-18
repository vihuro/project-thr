using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.auth.Service.ExceptionService;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Peca
{
    public class PecaService : IPecaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public PecaService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> DeleteAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReturnPecasDto>> GetAll()
        {
            var obj = await _context.Pecas
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .AsNoTracking()
                .OrderBy(c => c.CodigoRadar)
                .ToListAsync() ??

                throw new CustomException("Peça não encontrada!") { HResult = 404 };

            return _mapper.Map<List<ReturnPecasDto>>(obj);
        }

        public async Task<ReturnPecasDto> GetById(Guid id)
        {
            var obj = await _context.Pecas
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ??

                throw new CustomException("Peça não encontrada!") { HResult = 404 };

            return _mapper.Map<ReturnPecasDto>(obj);

        }

        public async Task<ReturnPecasDto> InsertPecas(InsertPecaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Preco.ToString()) ||
                string.IsNullOrWhiteSpace(dto.Descricao) ||
                string.IsNullOrWhiteSpace(dto.CodigoRadar))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var obj = _mapper.Map<PecasModel>(dto);

            _context.Pecas.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
    }
}
