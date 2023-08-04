using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using API.ESTOQUE_GRM_MATRIZ.Models.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Service.ExceptionBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Estoque
{
    public class SubstitutosService : ISubstitutosService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IEstoqueService _estoqueService;


        public SubstitutosService(IMapper mapper, 
                                    Context context,
                                    IEstoqueService estoqueService)
        {
            _mapper = mapper;
            _context = context;
            _estoqueService = estoqueService;
        }

        public async Task<bool> DeleteAll()
        {
            var objList = await _context.Substituto
                .ToListAsync();
            _context.Substituto.RemoveRange(objList);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteById(DeleteSubstitutoById dto)
        {
            var obj = await _context.Substituto
                .FirstOrDefaultAsync(x => x.SubstitutoId == dto.SubstitutoId && x.MaterialEstoqueId == dto.ProdutoId) ??
                throw new CustomException("Substituto não encontrado!") { HResult = 404 };

            _context.Substituto.Remove(obj);
            await _context.SaveChangesAsync();
            await _estoqueService.UpdateDateTimeChange(obj.MaterialEstoqueId,dto.UsuarioId);

            return true;

        }

        public async Task<List<ReturnSubstitutoDto>> GetAll()
        {
            var objList = await _context.Substituto
                .AsNoTracking()
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadatro)
                .Include(e => e.MaterialEstoque)
                    .ThenInclude(e => e.LocalArmazenagem)
                .Include(e => e.MaterialEstoque)
                    .ThenInclude(t => t.TipoMaterial)
                .Include(e => e.MaterialEstoque)
                    .ThenInclude(l => l.LocalArmazenagem)
                .Include(e => e.Substituto)
                    .ThenInclude(s => s.Substituos)
                    .Include(s => s.Substituto.LocalArmazenagem)
                    .Include(s => s.Substituto.TipoMaterial)
                .ToListAsync();
            var dto = _mapper.Map<List<ReturnSubstitutoDto>>(objList);

            return dto;
        }

        public async Task<ReturnSubstitutoDto> GetById(Guid id)
        {
            var obj =await _context.Substituto
                .AsNoTracking()
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadatro)
                .Include(e => e.MaterialEstoque)
                    .ThenInclude(e => e.LocalArmazenagem)
                .Include(e => e.MaterialEstoque)
                    .ThenInclude(t => t.TipoMaterial)
                .Include(e => e.MaterialEstoque)
                    .ThenInclude(l => l.LocalArmazenagem)
                .Include(e => e.Substituto)
                    .ThenInclude(s => s.Substituos)
                    .Include(s => s.Substituto.LocalArmazenagem)
                    .Include(s => s.Substituto.TipoMaterial)
                 .FirstOrDefaultAsync(x => x.Id == id) ?? 

                throw new CustomException("Substituto não encontrado!") { HResult = 404 };

            var dto = _mapper.Map<ReturnSubstitutoDto>(obj);

            return dto;

        }

        public async Task<ReturnSubstitutoDto> UpdateSubstituto(UpdateSubstitutoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SubstitutoId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.ProdutoId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.UsuarioId.ToString()))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var verify = await _context.Substituto
                .AsNoTracking()
                .AnyAsync(x => x.MaterialEstoqueId == dto.ProdutoId &&
                        x.SubstitutoId == dto.SubstitutoId);
            if (verify) 
                 throw new CustomException("Esse substituto já está cadastrado para esse material!");
            var obj = _mapper.Map<SubstitutoModel>(dto);

            _context.Substituto.Add(obj);
            await _context.SaveChangesAsync();

            await _estoqueService.UpdateDateTimeChange(dto.ProdutoId, dto.UsuarioId);

            return await GetById(obj.Id);
        }
    }
}
