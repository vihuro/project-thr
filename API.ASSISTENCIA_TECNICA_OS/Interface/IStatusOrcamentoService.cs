using API.ASSISTENCIA_TECNICA_OS.DTO.Status;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IStatusOrcamentoService
    {
        Task ApontarAguardandoOrcamento(ReturnStatusOnBudgetDto dto);
        Task ApontarOrcamentoFinalizado(ReturnStatusOnBudgetDto dto);
        //Task ApontarNegociacaoIniciada(ReturnStatusOnBudgetDto dto);
        //Task ApontarNegociacaoFinalizada(ReturnStatusOnBudgetDto dto);
        Task ApontarOrcamentoAprovado(ReturnStatusOnBudgetDto dto);
        Task ApontarOrcamentoReprovado(ReturnStatusOnBudgetDto dto);
        Task ApontarManutencaoIniciada(ReturnStatusOnBudgetDto dto);
        Task ApontarManutencaoFinalizada(ReturnStatusOnBudgetDto dto);
    }
}
