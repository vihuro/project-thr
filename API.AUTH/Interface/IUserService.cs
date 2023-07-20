using API.AUTH.Dto.user;
using API.AUTH.Dto.user.Token;
using System.Threading.Tasks;

namespace API.AUTH.Interface
{
    public interface IUserService
    {
        Task<ReturnUserDto> Insert(RegisterUserDto dto);
        Task<List<ReturnUserDto>> GetAll();
        Task<ReturnUserDto> GetById(Guid id);
        Task<ReturnUserDto> GetByUserName(string apelido);
        Task<TokenDto> Login(LoginDto dto);
        Task<ReturnUserDto> ChangePassword(ChangePassword dto);
        Task<ReturnUserDto> ChangePasswordOrActive(ChangePasswordOrActive dto);
        Task<ReturnUserDto> ChangeDateTimeChange(Guid id);
        Task<bool> DeleteUser(Guid id);
        Task<bool> DeleteAll();
        

    }
}
