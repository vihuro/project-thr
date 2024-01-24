using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IOrcamentoService
    {
        Task<ReturnOrcamentoDto> InsertOrcamento(InsertOrcamentoDto dto);
        Task<ReturnOrcamentoDto> GetById(int numeroOrcamento);
        Task<List<ReturnOrcamentoResumidoDto>> GetAll();
        Task<List<ReturnOrcamentoDto>> GetByNumeroSerieMaquina(string numeroSerie);
        Task<List<ReturnOrcamentoDto>> GetByBI();
        Task<ReturnOrcamentoDto> InsertObservacao(InsertObservacaoDto dto);
        Task<ReturnOrcamentoDto> UpdateTecnicoNoOrcamento(UpdateTecnicoNoOrcamentoOuNaManutencaoDto dto);
        Task<ReturnOrcamentoDto> UpdatestatusForOrcando(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForAguardandoLiberacaoOrcamento(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForOrcamentoRecusado(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForAguardandoSeparacaoPecas(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForSeparacaoPecasFinalizada(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForManutencaoIniciada(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForManutencaoFinalizada(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusForLimpezaIniciada(UpdateStatusOnBudgetDto dto);
        Task<ReturnOrcamentoDto> UpdateStatusOrcamentoFinalizado(UpdateStatusOnBudgetDto dto);

    }
}
