using API.AUTH.Dto.Claims;
using API.AUTH.Dto.ClaimsForUser;

namespace API.AUTH.Interface
{
    public interface IClaimsForUserService
    {
        Task<ReturnClaimsForUserDto> Insert(InsertClaimsForUserDto dto);
        Task<List<ReturnClaimsForUserDto>> GetAll();
        Task<ReturnClaimsForUserDto> GetById(Guid id);
        Task<List<ReturnClaimsForUserDto>> GetByClaimId(Guid id);
        Task<List<ReturnClaimsForUserDto>> GetByUserId(Guid id);
        Task<bool> DeleteAll();

    }
}
