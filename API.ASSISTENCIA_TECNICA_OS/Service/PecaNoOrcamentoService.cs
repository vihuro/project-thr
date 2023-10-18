using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas.PecasNoOrcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service
{
    public class PecaNoOrcamentoService
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
        public async Task<List<ReturnPecasOrcamentoDto>> InsertPecasNoOrcamento(InsertPecasNoOrcamentoDto dto)
        {
            var orcamento = await _orcamentoService.GetById(dto.NumeroOcamento);

            var listObjPecas = new List<PecasMaquinaOrcamentoModel>();

            foreach (var item in dto.Pecas)
            {
                listObjPecas.Add(new PecasMaquinaOrcamentoModel
                {
                    PecaId = item.PecaId,
                    Conserto = true,
                    Quantidade = 0,
                    Troca = false,
                    Reaproveitamento = false,
                    OrcamentoId = dto.NumeroOcamento,
                    MaquinaId = orcamento.Maquina.MaquinaId,
                });
            }
            _context.PecasPorOrdemServico.AddRange(listObjPecas);
            await _context.SaveChangesAsync();

            return new List<ReturnPecasOrcamentoDto>();

        }
    }
}
