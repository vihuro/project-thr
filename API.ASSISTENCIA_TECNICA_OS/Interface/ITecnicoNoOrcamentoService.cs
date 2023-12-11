using API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface ITecnicoNoOrcamentoService
    {
        Task InsertTecnicoNoOrcamento(InsertTecnicoNoOrcamentoDto dto);
    }
}
