using API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface ITecnicoService
    {
        Task<List<ReturnTecnicoDto>> GetAll();
        Task<ReturnTecnicoDto> GetById(Guid id);
        Task<ReturnTecnicoDto> InsertTecnico(InsertTecnicoDto dto);
    }
}
