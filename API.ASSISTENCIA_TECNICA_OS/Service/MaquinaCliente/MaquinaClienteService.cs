using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.auth.Service.ExceptionService;

namespace API.ASSISTENCIA_TECNICA_OS.Service.MaquinaCliente
{
    public class MaquinaClienteService : IMaquinaClienteService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MaquinaClienteService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteMaquinaInCliente(Guid id)
        {
            var obj = _context.MaquinaCliente.FirstOrDefaultAsync(x => x.MaquinaId == id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> MaquinaAtribuida(Guid maquinaId)
        {
            var obj = await _context.MaquinaCliente.Where(x => x.MaquinaId == maquinaId).ToListAsync();

            if (obj.Count > 1) return true;

            return false;
        }

        public async Task<ReturnMaquinaClienteDto> UpdateMaquinaInCliente(InsertMaquinaInClientDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MaquinaId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.ClienteId.ToString()))
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var verify = await _context.MaquinaCliente.AnyAsync(x => x.MaquinaId == dto.MaquinaId);
            if (verify)
                throw new CustomException("Essa máquina já está em uso!");

            var obj = _mapper.Map<MaquinaClienteModel>(dto);

            _context.MaquinaCliente.Add(obj);
            await _context.SaveChangesAsync();

            obj = await _context.MaquinaCliente
                .Include(x => x.Maquina)
                .Include(x => x.Cliente)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            return _mapper.Map<ReturnMaquinaClienteDto>(obj);

        }
    }
}
