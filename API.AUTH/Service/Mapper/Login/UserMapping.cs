using API.AUTH.Dto.Claims;
using API.AUTH.Dto.user;
using API.AUTH.Models.Claims;
using API.AUTH.Models.User;
using AutoMapper;
using static BCrypt.Net.BCrypt;

namespace API.AUTH.Service.Mapper.Login
{
    public class UserMapping : Profile
    {
        public UserMapping() 
        {
            //De DTO para Model
            CreateMap<RegisterUserDto, UserModel>()
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido))
                .ForMember(x => x.Senha, map => map.MapFrom(src => HashPassword(src.Senha)))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => true))
                .ForPath(x => x.ClaimsForUser, map => map.MapFrom(src => src.Claims.Select(c => new ClaimsForUserModel()
                {
                    TypeClaimsId = c.ClaimId

                })))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow));

            //De Model para DTO
            CreateMap<UserModel, ReturnUserDto>()
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido))
                .ForMember(x => x.UsuarioId, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => src.DataHoraCadastro))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => src.DataHoraAlteracao))
                .ForPath(x => x.Claims, map => map.MapFrom(src => src.ClaimsForUser.Select(c => new ReturnClaimsForUser()
                {
                    id = c.Id,
                    ClaimId = c.TypeClaimsId,
                    ClaimName = c.TypeClaims.Name,
                    ClaimValue = c.TypeClaims.Value,
                })));

            CreateMap<ReturnUserDto, UserModel>()
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Apelido))
                .ForMember(x => x.Id, map => map.MapFrom(src => src.UsuarioId));
        }
    }
}
