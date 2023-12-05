using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.DTO.User;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.User;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using API.ASSISTENCIA_TECNICA_OS.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace API.ASSISTENCIA_TECNICA_OS.Service.User
{
    public class UserAuthService : IUserService
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private static AndressApiAuth _andress;

        public UserAuthService(Context context, IConfiguration configuration, IOptions<AndressApiAuth> andress)
        {
            _context = context;
            _configuration = configuration;
            _andress = andress.Value;
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

        private static async Task<List<ReturnUserAuthDto>> GetUserAuth()
        {

            using var cliente = new HttpClient();

            //var responseApiAuth = await cliente.GetAsync("http://192.168.1.87:8080/api/v1/auth/login");

            var responseApiAuth = await cliente.GetAsync(_andress.Andress);

            if (responseApiAuth.IsSuccessStatusCode)
            {
                var content = await responseApiAuth.Content.ReadAsStringAsync();
                var objResponse = JsonConvert.DeserializeObject<ReturnListUserDto>(content);

                return objResponse.DataUsers;
            }
            throw new CustomException("ERRO AO BUSCAR USUÁRIOS");
        }

        public async Task Insert(UserDto user)
        {
            var obj = await _context.User
                            .SingleOrDefaultAsync(x => 
                             x.Id == user.UsuarioId);
            if(obj == null)
            {
                obj = new UserModel
                {
                    Id = user.UsuarioId,
                    Apelido = user.Apelido,
                    Nome = user.Nome
                };
            }
            obj.Ativo = user.Ativo;
            _context.User.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
