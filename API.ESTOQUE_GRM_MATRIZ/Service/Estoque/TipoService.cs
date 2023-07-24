using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using API.ESTOQUE_GRM_MATRIZ.Models.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Service.ExceptionBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Estoque
{
    public class TipoService : ITipoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TipoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReturnType> Insert(InsertTypeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Tipo) ||
                string.IsNullOrWhiteSpace(dto.UsuarioId.ToString()))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var verify = await _context.TipoMaterial.FirstOrDefaultAsync(x => x.TipoMaterial == dto.Tipo.ToUpper());

            if (verify != null)
                throw new CustomException("Tipo de material já cadatrado!");

            var obj = _mapper.Map<TipoMaterialModel>(dto);
            _context.TipoMaterial.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }

        public async Task<ReturnType> GetById(Guid id)
        {
            var obj = await _context.TipoMaterial
                .Include(u => u.UserChange)
                .Include(u => u.UserRegister)
                .FirstOrDefaultAsync(x => x.Id == id) ?? 

                throw new CustomException("Tipo não encontrado!") { HResult = 404 };

            var dto = _mapper.Map<ReturnType>(obj);

            return dto;
        }
        public async Task<List<ReturnType>> GetAll()
        {
            var objList = await _context.TipoMaterial
                .Include(u => u.UserChange)
                .Include(u => u.UserRegister)
                .ToListAsync();

            return _mapper.Map<List<ReturnType>>(objList);
        }
        public async Task<bool> DelteAll()
        {
            var objList = await _context.TipoMaterial.ToListAsync();
            _context.RemoveRange(objList);

            return true;
        }
    }
}
