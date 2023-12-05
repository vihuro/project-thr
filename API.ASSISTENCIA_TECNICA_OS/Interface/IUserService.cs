using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IUserService
    {
        Task Insert(UserDto user);
        Task<string> VerifyUsers();
    }
}
