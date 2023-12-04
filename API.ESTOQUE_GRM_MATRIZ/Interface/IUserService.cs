using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface IUserService
    {
        Task<bool> Inset(UserDto dto);
    }
}
