using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IOrcamentoService
    {
        Task<ReturnOrcamentoDto> InsertOrcamento(InsertOrcamentoDto dto);
        Task<ReturnOrcamentoDto> GetById(int numeroOrcamento);
        Task<List<ReturnOrcamentoResumidoDto>> GetAll();
        Task<ReturnOrcamentoDto> UpdateStatusForAguardandoOrcamento(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForAguardandoLiberacaoOrcamento(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForOrcamentoRecusado(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForAguardandoManutencao(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForManutencaoIniciada(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForManutencaoFinalizada(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForLimpezaIniciada(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusOrcamentoFinalizado(UpdateStatusOnBudgetDto dto);

    }
}
