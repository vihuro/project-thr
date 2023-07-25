using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using API.ESTOQUE_GRM_MATRIZ.Models.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Service.ExceptionBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Estoque
{
    public class EstoqueService : IEstoqueService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EstoqueService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteAll()
        {
            var list = await _context.Estoque.ToListAsync();
            _context.Estoque.RemoveRange(list);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ReturnEstoqueDto>> GetAll()
        {
            var list = await _context.Estoque
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(s => s.Substituos)
                    .ThenInclude(s => s.Substituto)
                    .ThenInclude(l => l.LocalArmazenagem)
                .Include(t => t.Substituos)
                    .ThenInclude(s => s.Substituto)
                    .ThenInclude(t => t.TipoMaterial)

                .Include(l => l.LocalArmazenagem)
                .Include(t => t.TipoMaterial)
                .AsNoTracking()
                .ToListAsync();
            var dto = _mapper.Map<List<ReturnEstoqueDto>>(list);

            return dto;
        }

        public async Task<ReturnEstoqueDto> GetById(Guid id)
        {
            var obj = await _context.Estoque
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(s => s.Substituos)
                .Include(l => l.LocalArmazenagem)
                .Include(t => t.TipoMaterial)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ??

                throw new CustomException("Material não encontrado!") { HResult = 404 };

            var dto = _mapper.Map<ReturnEstoqueDto>(obj);

            return dto;
        }

        public async Task<ReturnEstoqueDto> Insert(InsertEstoqueDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Unidade) ||
                string.IsNullOrWhiteSpace(dto.Codigo) ||
                string.IsNullOrWhiteSpace(dto.Descricao) ||
                string.IsNullOrWhiteSpace(dto.Quantidade.ToString()) ||
                string.IsNullOrWhiteSpace(dto.LocalEstoqueId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.UsuarioId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.TipoMaterialId.ToString()))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var verify = await _context.Estoque
                .AsNoTracking()
                .Where(x => x.Codigo == dto.Codigo &&
                                    x.Descricao == dto.Descricao)
                .ToListAsync();

           
            var objExisting = verify.SelectMany(c => c.Substituos.Select(x => x.SubstitutoId));
            var substitutos = dto.Substitutos?.Select(x => x.SubstitutoId);

            if (objExisting.Intersect(substitutos).Any())
                throw new CustomException("Código já cadastrado!");

            var obj =  _mapper.Map<EstoqueModel>(dto);

            _context.Estoque.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }

    }
}
