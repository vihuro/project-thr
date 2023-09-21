using API.ASSISTENCIA_TECNICA_OS.DTO.User;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IUserService
    {
        Task<string> VerifyUsers();
    }
}
