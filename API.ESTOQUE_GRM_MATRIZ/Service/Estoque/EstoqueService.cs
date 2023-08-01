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
                    .ThenInclude(s => s.Substituto)
                    .ThenInclude(l => l.LocalArmazenagem)
                .Include(t => t.Substituos)
                    .ThenInclude(s => s.Substituto)
                    .ThenInclude(t => t.TipoMaterial)

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

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            var verify = await _context.Estoque
                .AsNoTracking()
                .Where(x => x.Codigo == dto.Codigo &&
                                    x.Descricao == dto.Descricao)
                .ToListAsync();
            var verifyLocale = verify.Any(x => x.LocalArmazenagemId == dto.LocalEstoqueId);

            if(verifyLocale)
                throw new CustomException("Código já cadastrado!") { HResult = 400 };


            var obj = _mapper.Map<EstoqueModel>(dto);

            _context.Estoque.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }

        public async Task<ReturnEstoqueDto> UpdateQuantidade(UpdateQuantidadeDto dto)
        {
            var obj = await _context.Estoque

                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.MaterialId) ??
                throw new CustomException("Material não encontrado!") { HResult = 404 };

            var novaQuantidade = obj.Quantidade += dto.Quantidade;
            if (novaQuantidade < 0)
                throw new CustomException("Não é possivel fazer uma movimentação com saldo menor que zero!") { HResult = 400 };
            obj.Quantidade = novaQuantidade;
            obj.UsuarioAlteracaoId = dto.UsuarioId;
            obj.DataHoraAlteracao = DateTime.UtcNow;

            _context.Estoque.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
        public async Task<List<ReturnEstoqueDto>> UpdateQuantidadeZero()
        {
            var objList = await _context.Estoque.ToListAsync();
            foreach (var item in objList)
            {
                item.Quantidade = 0;
            }
            _context.Estoque.UpdateRange(objList);
            await _context.SaveChangesAsync();

            return await GetAll();
        }
    }
}
