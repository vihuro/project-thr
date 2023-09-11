using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.DTO.OrdemServico;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Maquina
{
    public class MaquinaMapping : Profile
    {
        public MaquinaMapping() 
        {
            CreateMap<InsertMaquinaDto, MaquinaModel>()
                .ForMember(x => x.Ativo, map => map.MapFrom(src => true))
                .ForMember(x => x.NumeroSerie, map => map.MapFrom(src => src.NumeroSerie))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow));

            CreateMap<ReturnMaquinaComPecasDto, ReturnMaquinaDto>()
                .ForMember(x => x.MaquinaId, map => map.MapFrom(src => src.Id));
        }
    }
}
