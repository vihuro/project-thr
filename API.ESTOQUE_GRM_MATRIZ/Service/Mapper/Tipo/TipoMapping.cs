using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Models.TipoMaterial;
using AutoMapper;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Tipo
{
    public class TipoMapping : Profile
    {
        public TipoMapping()
        {
            CreateMap<InsertTypeDto, TipoMaterialModel>()
                .ForMember(x => x.DataTimeRegister, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.DataTimeChange, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.TipoMaterial,map => map.MapFrom(src => src.Tipo.ToUpper()))
                .ForMember(x => x.UserChangeId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.UserRegisterId, map => map.MapFrom(src => src.UsuarioId));

            CreateMap<TipoMaterialModel, ReturnType>()
                .ForMember(x => x.Tipo, map => map.MapFrom(src => src.TipoMaterial))
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UsertDateTime
                {
                    Apelido = src.UserRegister.Apelido,
                    DataHora = src.DataTimeRegister,
                    Id = src.UserRegister.Id,
                    Nome = src.UserRegister.Nome
                })).
                ForPath(x => x.Alteracao, map => map.MapFrom(src => new UsertDateTime
                {
                    Apelido = src.UserChange.Apelido,
                    DataHora = src.DataTimeChange,
                    Id = src.UserChange.Id,
                    Nome = src.UserChange.Nome
                }));


        }
    }
}
