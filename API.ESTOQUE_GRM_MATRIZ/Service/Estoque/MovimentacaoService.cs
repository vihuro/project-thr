using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Movimentacao;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using API.ESTOQUE_GRM_MATRIZ.Models.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Service.ExceptionBase;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Estoque
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IEstoqueService _service;

        public MovimentacaoService(Context context,
                                    IMapper mapper,
                                    IEstoqueService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        public async Task<bool> DeleteAll()
        {
            var objList = await _context.Movimentacao
                                        .ToListAsync();
            _context.Movimentacao.RemoveRange(objList);

            _ = await _service.UpdateQuantidadeZero() ??
                throw new CustomException("Problemas com o serviço de estoque!");

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ReturnMovimentacao> GetById(Guid id)
        {
            var obj = await _context.Movimentacao
                .Include(u => u.UsuarioMovimentacao)
                .Include(e => e.Material)
                .Include(e => e.Material.TipoMaterial)
                .Include(e => e.Material.LocalArmazenagem)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            var dto = _mapper.Map<ReturnMovimentacao>(obj);

            return dto;
        }
        public async Task<List<ReturnMovimentacao>> GetByMaterialId(Guid id)
        {
            var obj = await _context.Movimentacao
                .Include(u => u.UsuarioMovimentacao)
                .Include(e => e.Material)
                .Include(e => e.Material.TipoMaterial)
                .Include(e => e.Material.LocalArmazenagem)
                .AsNoTracking()
                .Where(x => x.MaterialId == id)
                .ToListAsync() ??
                throw new CustomException("Movimentação para esse material não encontrada!") { HResult = 404 };
            var dto = _mapper.Map<List<ReturnMovimentacao>>(obj);

            return dto;
        }
        public async Task<List<ReturnMovimentacao>> GetAll()
        {
            var obj = await _context.Movimentacao
                .Include(u => u.UsuarioMovimentacao)
                .Include(e => e.Material)
                .Include(e => e.Material.TipoMaterial)
                .Include(e => e.Material.LocalArmazenagem)
                .AsNoTracking()
                .ToListAsync();
            var dto = _mapper.Map<List<ReturnMovimentacao>>(obj);

            return dto;
        }

        public async Task<ReturnMovimentacao> Insert(UpdateMovimentacaoQuantidadeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.QuantidadeMovimentada.ToString()) ||
                string.IsNullOrWhiteSpace(dto.MaterialId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.UsuarioId.ToString()))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            var obj = await ValidateMovimentacao(dto);

            _context.Movimentacao.Add(obj);

            var estoque = new UpdateQuantidadeDto
            {
                MaterialId = dto.MaterialId,
                Quantidade = obj.QuantidadeMovimentada,
                UsuarioId = dto.UsuarioId,
            };
            _ = await _service.UpdateQuantidade(estoque) ??
                throw new CustomException("Problema para salvar no estoque a alteração!");

            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }

        private async Task<MovimentacaoModel> ValidateMovimentacao(UpdateMovimentacaoQuantidadeDto dto)
        {
            var obj = new MovimentacaoModel
            {
                MaterialId = dto.MaterialId,
                UsuarioMovimentacaoId = dto.UsuarioId,
                DataHoraMovimentacao = DateTime.UtcNow,
                TipoMovimentacao = dto.Tipo.ToString(),
                Destino = dto.Destino
            };

            var materialEstoque = await _service.GetById(dto.MaterialId);

            double quantidade = dto.Tipo ==
                TipoMovimentacao.SAIDA ? -dto.QuantidadeMovimentada : dto.QuantidadeMovimentada;


            obj.QuantidadeMovimentada = quantidade;
            obj.QuantidadeDestino = materialEstoque.Quantidade + obj.QuantidadeMovimentada;
            obj.QuantidadeOrigem = materialEstoque.Quantidade;

            return obj;
        }
    }
}
