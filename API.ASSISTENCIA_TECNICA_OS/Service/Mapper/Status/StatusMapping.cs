using API.ASSISTENCIA_TECNICA_OS.DTO.Status;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Status
{
    public class StatusMapping : Profile
    {
        public StatusMapping() 
        {
            CreateMap<InsertStatusDto, StatusModel>()
                .ForMember(x => x.Status, map => map.MapFrom(src => src.Status.ToUpper()));

            CreateMap<string, StatusModel>()
                .ForMember(x => x.Status, map => map.MapFrom(src => src.ToUpper()));

            CreateMap<StatusModel, ReturnStatusDto>()
                .ForMember(x => x.Status, map => map.MapFrom(src => src.Status))
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id));
        }
    }
}
