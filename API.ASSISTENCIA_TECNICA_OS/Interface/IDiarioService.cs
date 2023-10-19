using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IDiarioService
    {
        Task<ReturnDiarioOrcamentoDto> InsertInformaca(InsertInformacaoDiarioDto dto);
        Task<ReturnDiarioOrcamentoDto> GetByNumeroApontamento(int numeroApontamento);
    }
}
