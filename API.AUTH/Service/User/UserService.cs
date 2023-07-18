﻿using API.AUTH.ContextBase;
using API.AUTH.Dto.user;
using API.AUTH.Dto.user.Token;
using API.AUTH.Interface;
using API.AUTH.Models.User;
using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using THR.auth.Service.ExceptionService;
using static BCrypt.Net.BCrypt;

namespace API.AUTH.Service.User
{
    public class UserService : IUserService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly ICreateTokenService _createTokenService;

        public UserService(Context context,
                            IMapper mapper,
                            ICreateTokenService createTokenService)
        {
            _context = context;
            _mapper = mapper;
            _createTokenService = createTokenService;
        }

        public async Task<ReturnUserDto> ChangePassword(ChangePassword dto)
        {
            var user = await _context.UserModels
                                    .FirstOrDefaultAsync(x => x.Id == dto.UserId) ??
                                    throw new CustomException("Usuário inválido!") { HResult = 404 };

            user.DataHoraAlteracao = DateTime.UtcNow;
            user.Senha = HashPassword(dto.Senha) ?? user.Senha;
            _context.UserModels.Update(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserModel, ReturnUserDto>(user);
        }

        public async Task<ReturnUserDto> ChangePasswordOrActive(ChangePasswordOrActive dto)
        {
            var user = await _context.UserModels
                                    .FirstOrDefaultAsync(x => x.Id == dto.UserId) ??
                                    throw new CustomException("Usuário inválido!") { HResult = 404 };

            user.DataHoraAlteracao = DateTime.UtcNow;
            user.Ativo = dto.Ativo ?? user.Ativo;
            user.Senha = HashPassword(dto.Senha) ?? user.Senha;
            _context.UserModels.Update(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserModel, ReturnUserDto>(user);
        }

        public async Task<bool> DeleteAll()
        {
            var obj = await _context.UserModels
                                .ToListAsync();

            _context.UserModels.RemoveRange(obj);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var obj = await _context.UserModels
                                .FirstOrDefaultAsync(x => x.Id == id);

            _context.UserModels.RemoveRange(obj);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ReturnUserDto>> GetAll()
        {
            var obj = await _context.UserModels
                .Include(c => c.ClaimsForUser)
                    .ThenInclude(c => c.TypeClaims)
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<List<UserModel>, List<ReturnUserDto>>(obj);
        }

        public async Task<ReturnUserDto> GetById(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString())) throw new CustomException("Campo obrigatório vazio!");
            var obj = await _context.UserModels
                .Include(c => c.ClaimsForUser)
                    .ThenInclude(c => c.TypeClaims)
                 .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ??

            throw new CustomException("Usuário não econtrado") { HResult = 404 };

            return _mapper.Map<UserModel, ReturnUserDto>(obj);
        }

        public async Task<ReturnUserDto> GetByUserName(string apelido)
        {
            if (string.IsNullOrEmpty(apelido)) throw new CustomException("Campo obrigatório vazio!");
            var obj = await _context.UserModels
                .Include(c => c.ClaimsForUser)
                    .ThenInclude(c => c.TypeClaims)
                 .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Apelido == apelido) ??

            throw new CustomException("Usuário não econtrado") { HResult = 404 };

            return _mapper.Map<UserModel, ReturnUserDto>(obj);
        }

        public async Task<ReturnUserDto> Insert(RegisterUserDto dto)
        {
            if (string.IsNullOrEmpty(dto.Senha) ||
                string.IsNullOrEmpty(dto.Apelido) ||
                string.IsNullOrEmpty(dto.Nome))
            {
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");
            }
            var obj = _mapper.Map<RegisterUserDto, UserModel>(dto);
            _context.UserModels.Add(obj);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserModel, ReturnUserDto>(obj);
        }

        public async Task<TokenDto> Login(LoginDto dto)
        {
            if (string.IsNullOrEmpty(dto.Apelido) ||
                string.IsNullOrEmpty(dto.Senha)) throw new CustomException("Usuário ou senha inválidos");

            var obj = await _context.UserModels
                .Include(c => c.ClaimsForUser)
                    .ThenInclude(c => c.TypeClaims)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Apelido.ToLower() == dto.Apelido.ToLower());

            if (obj == null) throw new CustomException("Usuário ou senha inváildos");
            var valid = Verify(dto.Senha, obj.Senha);

            if (!valid) throw new CustomException("Usuário ou senha inváildos");

            var convert = _mapper.Map<UserModel, ReturnUserDto>(obj);

            var token = _createTokenService.Token(convert);

            return token;
        }
    }
}
