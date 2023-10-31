using API.ASSISTENCIA_TECNICA_OS.DTO.Status;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IStatusOrcamentoService
    {
        Task<object> ApontarAguardandoOrcamento(ReturnStatusOnBudgetDto dto);
        Task<object> ApontarOrcamentoFinalizado(ReturnStatusOnBudgetDto dto);
    }
}
