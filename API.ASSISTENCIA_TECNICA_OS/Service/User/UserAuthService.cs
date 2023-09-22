using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.User;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;
using THR.auth.Service.ExceptionService;

namespace API.ASSISTENCIA_TECNICA_OS.Service.User
{
    public class UserAuthService : IUserService
    {
        private readonly Context _context;

        public UserAuthService(Context context)
        {
            _context = context;
        }

        public async Task<string> VerifyUsers()
        {
            var thisUsers = await _context.User.ToListAsync();

            var usersAuth = await GetUserAuth();

            var existsUser = usersAuth
                .Where(authUser => !thisUsers.Any(user => user.Id == authUser.UsuarioId))
                .ToList();
            var lisUser = new List<UserModel>();
            foreach (var item in existsUser)
            {
                lisUser.Add(new UserModel
                {
                    Apelido = item.Apelido,
                    Ativo = item.Ativo,
                    Nome = item.Nome,
                    Id = item.UsuarioId
                });
            }
            if (lisUser.Count > 0)
            {
                _context.AddRange(lisUser);
                await _context.SaveChangesAsync();

                return "USUÁRIO ADICIONADOS COM SUCESSO!";
            }


            return "NENHUM USUÁRIO PARA SER ADICIONADO!";
        }

        private async Task<List<ReturnUserAuthDto>> GetUserAuth()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://192.168.0.187:8080/api/v1/auth/login");

            using var cliente = new HttpClient();

            var responseApiAuth = await cliente.GetAsync("http://192.168.0.187:8080/api/v1/auth/login");

            if (responseApiAuth.IsSuccessStatusCode)
            {
                var content = await responseApiAuth.Content.ReadAsStringAsync();
                var objResponse = JsonConvert.DeserializeObject<ReturnListUserDto>(content);

                return objResponse.DataUsers;
            }
            throw new CustomException("ERRO AO BUSCAR USUÁRIOS");
        }
    }
}
