using API.ASSISTENCIA_TECNICA_OS.DTO;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IPecasRadarService
    {
        Task<List<PecasRadarDto>> GetAll();
        Task<List<PecasModel>> InsertPecas();
    }
}
