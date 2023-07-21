using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface IUserService
    {
        Task Inset(UserDto dto);
    }
}
