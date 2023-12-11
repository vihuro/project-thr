using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas.PecasNoOrcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Peca
{
    public class PecaNoOrcamentoService : IPecasNoOrcamentoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IOrcamentoService _orcamentoService;

        public PecaNoOrcamentoService(Context context, IMapper mapper, IOrcamentoService orcamentoService)
        {
            _context = context;
            _mapper = mapper;
            _orcamentoService = orcamentoService;
        }

        public async Task<bool> DeletePecaNoOrcamento(DeletePecaNoOrcamentoDto dto)
        {
            var pecaNoOrcamentoId = await _context.PecasPorOrdemServico
                                        .SingleOrDefaultAsync(x => x.PecaId == dto.PecaNoOrcamentoId) ??

                throw new CustomException("Peça não encontrada") { HResult = 404 };
            _context.PecasPorOrdemServico.Remove(pecaNoOrcamentoId);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ReturnPecasOrcamentoDto> InsertPecasNoOrcamento(InsertPecasNoOrcamentoDto dto)
        {
            var orcamento = await _orcamentoService.GetById(dto.NumeroOrcamento);
            if (orcamento == null)
                throw new CustomException("Orçamento não encontrado!") { HResult = 404 };

            var verifyExistingPartsInBudget = await _context.PecasPorOrdemServico
                                                .SingleOrDefaultAsync(x =>
                                                x.PecaId == dto.PecaId && x.Troca == dto.Troca);

            if (verifyExistingPartsInBudget == null)
            {
                verifyExistingPartsInBudget = new PecasMaquinaOrcamentoModel
                {
                    Conserto = dto.Conserto,
                    MaquinaId = orcamento.Maquina.MaquinaId,
                    OrcamentoId = dto.NumeroOrcamento,
                    Reaproveitamento = dto.Reaproveitamento,
                    PecaId = dto.PecaId,
                    Troca = dto.Troca,
                    DataHoraCadastro = DateTime.UtcNow,
                    UsuarioCadastroId = dto.UsuarioId
                };
            }

            verifyExistingPartsInBudget.UsuarioAlteracaoId = dto.UsuarioId;
            verifyExistingPartsInBudget.DataHoraAlteracao = DateTime.UtcNow;
            verifyExistingPartsInBudget.Quantidade += dto.Quantidade;

            _context.PecasPorOrdemServico.Update(verifyExistingPartsInBudget);


            await _context.SaveChangesAsync();

            return new ReturnPecasOrcamentoDto();

        }
    }
}
