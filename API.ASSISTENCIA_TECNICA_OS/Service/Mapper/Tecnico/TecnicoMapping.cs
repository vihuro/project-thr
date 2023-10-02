using API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Model.Tecnico;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Tecnico
{
    public class TecnicoMapping : Profile
    {
        public TecnicoMapping()
        {
            CreateMap<TecnicoModel, ReturnTecnicoDto>()
                .ForMember(x => x.IdTecnico, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.IdUsuario, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.Apelido, map => map.MapFrom(src => src.Usuario.Apelido))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Usuario.Nome));
        }
    }
}
