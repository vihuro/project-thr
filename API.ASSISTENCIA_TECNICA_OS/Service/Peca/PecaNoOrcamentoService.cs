using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas.PecasNoOrcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;

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
        public async Task<ReturnPecasOrcamentoDto> InsertPecasNoOrcamento(InsertPecasNoOrcamentoDto dto)
        {
            var orcamento = await _orcamentoService.GetById(dto.NumeroOrcamento);
            if (orcamento == null)
                throw new CustomException("Orçamento não encontrado!") { HResult = 404 };


            var obg = new PecasMaquinaOrcamentoModel
            {
                Conserto = dto.Conserto,
                MaquinaId = orcamento.Maquina.MaquinaId,
                OrcamentoId = dto.NumeroOrcamento,
                Quantidade = dto.Quantidade,
                Reaproveitamento = dto.Reaproveitamento,
                PecaId = dto.PecaId,
                Troca = dto.Troca,
                DataHoraCadastro = DateTime.UtcNow,
                UsuarioCadastroId = dto.UsuarioId,
                UsuarioAlteracaoId = dto.UsuarioId,
                DataHoraAlteracao = DateTime.UtcNow
            };
            _context.PecasPorOrdemServico.Add(obg);
            await _context.SaveChangesAsync();

            return new ReturnPecasOrcamentoDto();

        }
    }
}
