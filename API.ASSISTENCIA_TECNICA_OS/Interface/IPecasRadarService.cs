using API.ASSISTENCIA_TECNICA_OS.DTO;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IPecasRadarService
    {
        Task<List<PecasRadarDto>> GetAll();
    }
}
