using API.ASSISTENCIA_TECNICA_OS.DTO.Status;
using System.Threading.Tasks;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IStatusService
    {
        Task<ReturnStatusDto> Insert(InsertStatusDto dto);
        Task<ReturnStatusDto> GetById(Guid id);
        Task<List<ReturnStatusDto>> GetAll();
    }
}
