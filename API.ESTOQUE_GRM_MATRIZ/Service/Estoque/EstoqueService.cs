using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
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
            var substis = await _context.Substituto.ToListAsync();
            _context.RemoveRange(substis);
            await _context.SaveChangesAsync();

            var list = await _context.Estoque
                .Include(s => s.Substituos)

                .AsNoTracking()
                .ToListAsync();

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
        public async Task<List<ReturnEstoqueDto>> GetAllForBI()
        {
            var list = await _context.Estoque
                .Where(x => x.Ativo == true)
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

        public async Task<ReturnEstoqueDto> GetById(int id)
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
                string.IsNullOrWhiteSpace(dto.TipoMaterialId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.DataFabricacao.ToString()) ||
                string.IsNullOrWhiteSpace(dto.Preco.ToString()))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            var verify = await _context.Estoque
                .AsNoTracking()
                .Where(x => x.Codigo == dto.Codigo &&
                            x.Descricao == dto.Descricao)
                .ToListAsync();
            var verifyLocale = verify.Any(x => x.LocalArmazenagemId == dto.LocalEstoqueId);

            if (verifyLocale)
                throw new CustomException("Código já cadastrado!") { HResult = 400 };


            var obj = _mapper.Map<EstoqueModel>(dto);

            _context.Estoque.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
        public async Task<List<ReturnEstoqueDto>> GetWithoutSubstituto(int id)
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
                .FirstOrDefaultAsync(x => x.Id == id);

            var objList = await _context.Estoque
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
                .Where(x => x.Id != id)
                .ToListAsync();

            var dto = _mapper.Map<List<ReturnEstoqueDto>>(objList);

            var list = dto
                .Where(item => item.Id != id)
                .Where(item => obj.Substituos.All(s => s.SubstitutoId != item.Id))
                .ToList();

            return list;
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
        public async Task<ReturnEstoqueDto> UpdateDateTimeChange(int produtoId, Guid usuarioId)
        {
            if (string.IsNullOrWhiteSpace(produtoId.ToString()) ||
                string.IsNullOrWhiteSpace(usuarioId.ToString()))
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };
            var obj = await _context.Estoque
                .FirstOrDefaultAsync(x => x.Id == produtoId);
            if (obj == null)
                throw new CustomException("Produto não encontrado!") { HResult = 404 };
            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = usuarioId;
            _context.Estoque.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
        public async Task<ReturnEstoqueDto> UpdateQuantidadeOrUnidade(UpdateQuantidadeOrUnidadeDto dto)
        {
            var obj = await _context.Estoque
                .FirstOrDefaultAsync(x => x.Id == dto.ProdutoId);
            if (obj == null)
                throw new CustomException("Produto não encontrado!") { HResult = 404 };
            obj.Unidade = dto.Unidade;
            obj.TipoMaterialId = dto.TipoId;
            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            _context.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
        public async Task<ReturnEstoqueDto> UpdatePreco(UpdatePrecoDto dto)
        {
            var obj = await _context.Estoque
                .FirstOrDefaultAsync(x => x.Id == dto.ProdutoId) ??
                throw new CustomException("Produto não encontrado!") { HResult = 404 };
            if (dto.Preco < 0)
                throw new CustomException("Não é possível declar um preço negativo!") { HResult = 400 };

            obj.Preco = dto.Preco;
            obj.UsuarioAlteracaoId = dto.UsuarioId;
            obj.DataHoraAlteracao = DateTime.UtcNow;

            _context.Estoque.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);


        }
        public async Task<ReturnEstoqueDto> UpdateUltimoClienteCompra(UpdateUltimoClienteCompraDto dto)
        {
            var obj = await _context
                .Estoque
                .FindAsync(dto.MaterialId);
            if (obj == null) throw new CustomException("Material não encontrado!") { HResult = 404 };
            obj.ClienteUltimaCompra1 = dto.ClienteUltimaCompra1.ToUpper();
            obj.CodigoClienteUltimaCompra1 = dto.CodigoClienteUltimaCompra1.ToUpper();
            obj.ClienteUltimaCompra2 = dto.ClienteUltimaCompra2.ToUpper();
            obj.CodigoClienteUltimaCompra2 = dto.CodigoClienteUltimaCompra2.ToUpper();
            obj.ClienteUltimaCompra3 = dto.ClienteUltimaCompra3.ToUpper();
            obj.CodigoClienteUltimaCompra3 = dto.CodigoClienteUltimaCompra3.ToUpper();

            _context.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
    }
}
