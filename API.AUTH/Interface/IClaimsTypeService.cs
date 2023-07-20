using API.AUTH.Dto.Claims;

namespace API.AUTH.Interface
{
    public interface IClaimsTypeService
    {
        Task<ReturnTypeClaimsDto> Insert(RegisterClaimDto dto);
        Task<List<ReturnTypeClaimsDto>> GetAll();
        Task<ReturnTypeClaimsDto> GetById(Guid id);
        Task<List<ReturnTypeClaimsDto>> GetByName(string ClaimName);
        Task<List<ReturnTypeClaimsDto>> GetByValue(string ClaimValue);
        Task<ReturnTypeClaimsDto> GetByValueAndName(string ClaimValue, string ClaimName);
        Task<ReturnTypeClaimsDto> Update(RegisterClaimDto dto);
        Task<bool> DeleteAll();
        Task<bool> DeleteById(Guid id);
    }
}
