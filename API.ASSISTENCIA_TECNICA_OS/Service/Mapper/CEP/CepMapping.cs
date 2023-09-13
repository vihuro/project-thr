using API.ASSISTENCIA_TECNICA_OS.DTO.CEP;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.CEP
{
    public class CepMapping : Profile
    {
        public CepMapping() 
        {
            CreateMap<CepDto, ReturnCEPDto>()
                .ForMember(x => x.Cep, map => map.MapFrom(src => src.Cep))
                .ForMember(x => x.Regiao, map => map.MapFrom(src => src.Regiao))
                .ForMember(x => x.Estado, map => map.MapFrom(src => src.State))
                .ForMember(x => x.Cidade, map => map.MapFrom(src => src.Cidade))
                .ForMember(x => x.Rua, map => map.MapFrom(src => src.Rua))
                .ForMember(x => x.Service, map => map.MapFrom(src => src.Service));
        }
    }
}
