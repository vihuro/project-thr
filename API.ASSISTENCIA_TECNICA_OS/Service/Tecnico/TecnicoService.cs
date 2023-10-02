using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Tecnico
{
    public class TecnicoService : ITecnicoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TecnicoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnTecnicoDto> InsertTecnico(InsertTecnicoDto dto)
        {
            var verify = await _context.Tecnico.AnyAsync(x => x.UsuarioId == dto.UserId);

            if (verify) throw new CustomException("Técnico já cadastrado como técnico!");

            var obj = new TecnicoModel
            {
                UsuarioId = dto.UserId,
                Ativo = true
            };
            _context.Tecnico.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);

        }

        public async Task<ReturnTecnicoDto> GetById(Guid id)
        {
            var obj = await _context.Tecnico
                .Include(u => u.Usuario)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (obj == null) throw new CustomException("Técnico não encontrado!") { HResult = 404 };
            var dto = _mapper.Map<ReturnTecnicoDto>(obj);

            return dto;
        }
        public async Task<List<ReturnTecnicoDto>> GetAll()
        {
            var list = await _context.Tecnico
                .Include(u => u.Usuario)
                .ToListAsync();
            var dto = _mapper.Map<List<ReturnTecnicoDto>>(list);

            return dto;
        }
    }
}
