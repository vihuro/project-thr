using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas.PecasNoOrcamento;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IPecasNoOrcamentoService
    {
        Task<ReturnPecasOrcamentoDto> InsertPecasNoOrcamento(InsertPecasNoOrcamentoDto dto);
    }
}
