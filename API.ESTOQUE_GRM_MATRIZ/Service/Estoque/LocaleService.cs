using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using API.ESTOQUE_GRM_MATRIZ.Models.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Service.ExceptionBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Estoque
{
    public class LocaleService : ILocaleService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public LocaleService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteAll()
        {
            var list = await _context.Local.ToListAsync();
            _context.RemoveRange(list);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ReturnLocaleDto>> GetAll()
        {
            var objList = await  _context.Local
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .ToListAsync();

            var dto = _mapper.Map<List<ReturnLocaleDto>>(objList);

            return dto;
        }

        public async Task<ReturnLocaleDto> GetById(Guid id)
        {
            var objList = await _context.Local
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .FirstOrDefaultAsync(x => x.Id == id);

            var dto = _mapper.Map<ReturnLocaleDto>(objList);

            return dto;
        }

        public async Task<ReturnLocaleDto> Insert(InsertLocale dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Local) ||
                string.IsNullOrWhiteSpace(dto.UsuarioId.ToString()))
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var obj = _mapper.Map<LocalArmazenagemModel>(dto);
            _context.Local.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
    }
}
