using API.ESTOQUE_GRM_MATRIZ.ContextBase;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using API.ESTOQUE_GRM_MATRIZ.Models.User;
using Microsoft.EntityFrameworkCore;

namespace API.ESTOQUE_GRM_MATRIZ.Service.User
{
    public class UserService : IUserService
    {
        private readonly DbContextOptions<Context> _context;

        public UserService(DbContextOptions<Context> context)
        {
            _context = context;
        }

        public async Task<bool> Inset(UserDto dto)
        {
            await using var _db = new Context(_context);

            var obj = new UserAuthModel()
            {
                Apelido = dto.Apelido,
                Ativo = dto.Ativo,
                Id = dto.UsuarioId,
                Nome = dto.Nome,
            };
            _db.User.Add(obj);
            await _db.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Change(UserDto dto)
        {
            await using var _db = new Context(_context);

            var obj = await _db.User
                .FirstOrDefaultAsync(x => x.Id == dto.UsuarioId);
            obj.Ativo = dto.Ativo;
            _db.User.Update(obj);
            await _db.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleById(Guid id)
        {
            await using var _db = new Context(_context);
            var obj = await _db.User
                .FirstOrDefaultAsync(x => x.Id == id);
            _db.User.Remove(obj);

            await _db.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleAll()
        {
            await using var _db = new Context(_context);
            var obj = await _db.User
                .ToListAsync();
            _db.User.RemoveRange(obj);

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
