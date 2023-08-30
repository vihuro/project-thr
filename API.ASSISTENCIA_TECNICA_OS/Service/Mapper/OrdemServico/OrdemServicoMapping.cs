using API.ASSISTENCIA_TECNICA_OS.DTO.OrdemServico;
using API.ASSISTENCIA_TECNICA_OS.Model;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.OrdemServico
{
    public class OrdemServicoMapping : Profile
    {
        public OrdemServicoMapping() 
        {
            CreateMap<InsertOrdemDto, OSModel>()
                .ForMember(x => x.Status, map => map.MapFrom(src => true))
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.Descricao))
                .ForPath(x => x.MaquinaPorOs, map => map.MapFrom(src => src.Maquinas.Select(c => new MaquinasPorOsModel()
                {
                    MaquinaId = c.IdMaquina
                })));
            CreateMap<OSModel, ReturnOrdemDto>()
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.Descricao))
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Os))
                .ForPath(x => x.Maquinas, map => map.MapFrom(src => src.MaquinaPorOs.Select(c => new ReturnMaquinaDto
                {
                    Maquina = c.Maquina.TipoMaquina,
                    MaquinaId = c.MaquinaId
                })));
        }
    }
}
