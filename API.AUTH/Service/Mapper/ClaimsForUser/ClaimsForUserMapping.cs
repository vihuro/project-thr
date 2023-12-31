﻿using API.AUTH.Dto.ClaimsForUser;
using API.AUTH.Dto.user;
using API.AUTH.Models.Claims;
using API.AUTH.Models.User;
using AutoMapper;

namespace API.AUTH.Service.Mapper.ClaimsForUser
{
    public class ClaimsForUserMapping : Profile
    {
        public ClaimsForUserMapping()
        {
            CreateMap<InsertClaimsForUserDto, ClaimsForUserModel>()
                .ForMember(x => x.TypeClaimsId, map => map.MapFrom(src => src.ClaimId))
                .ForMember(x => x.UserClaimId, map => map.MapFrom(src => src.UserClaimsId));

            CreateMap<ClaimsForUserModel, ReturnClaimsForUserDto>()
                .ForMember(x => x.ClaimId, map => map.MapFrom(src => src.TypeClaimsId))
                .ForMember(x => x.ClaimName, map => map.MapFrom(src => src.TypeClaims.Name))
                .ForMember(x => x.ClaimValue, map => map.MapFrom(src => src.TypeClaims.Value))
                .ForMember(x => x.UsuarioClaim, map => map.MapFrom(src => new UserResumeWithoutDateOrTime
                {
                    Apelido = src.UserClaim.Apelido,
                    Nome = src.UserClaim.Nome,
                    UsuarioId = src.UserClaim.Id
                }));

        }
    }
}
