using API.AUTH.Dto.Claims;
using API.AUTH.Dto.user;
using API.AUTH.Models.Claims;
using AutoMapper;

namespace API.AUTH.Service.Mapper.Claims
{
    public class ClaimsTypeMapping : Profile
    {
        public ClaimsTypeMapping()
        {
            //DTO para Model
            CreateMap<RegisterClaimDto, TypeClaimsModel>()
                .ForMember(x => x.Name, map => map.MapFrom(src => src.Name))
                .ForMember(x => x.Value, map => map.MapFrom(src => src.Value))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.DataHoraCadatro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow));

            //Model para DTO
            CreateMap<TypeClaimsModel, ReturnTypeClaimsDto>()
                .ForMember(x => x.ClaimName, map => map.MapFrom(src => src.Name))
                .ForMember(x => x.ClaimValue, map => map.MapFrom(src => src.Value))
                .ForMember(x => x.ClaimId, map => map.MapFrom(src => src.Id))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UserResumeDateTimeDto()
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome = src.UsuarioCadastro.Nome,
                    UsuarioId = src.UsuarioCadastro.Id,
                    DataHora = src.DataHoraCadatro
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UserResumeDateTimeDto()
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    Nome = src.UsuarioAlteracao.Nome,
                    UsuarioId = src.UsuarioAlteracao.Id,
                    DataHora = src.DataHoraAlteracao
                }));


        }
    }
}
