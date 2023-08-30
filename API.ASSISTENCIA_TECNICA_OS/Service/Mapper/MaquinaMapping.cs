using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper
{
    public class MaquinaMapping: Profile
    {
        public MaquinaMapping()
        {
            CreateMap<InsertMaquinaDto, MaquinaModel>()
                .ForMember(x => x.Ativo, map => map.MapFrom(src => true))
                .ForMember(x => x.TipoMaquina, map => map.MapFrom(src => src.TipoMaquina))
                .ForPath(x => x.Pecas, map => map.MapFrom(src => src.Pecas.Select(c => new PecasPorMaquinaModel
                {
                    PecaId = c.IdPeca
                })));

            CreateMap<MaquinaModel, ReturnMaquinaComPecasDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => src.Ativo))
                .ForMember(x => x.TipoMaquina, map => map.MapFrom(src => src.TipoMaquina))
                .ForMember(x => x.Pecas, map => map.MapFrom(src => src.Pecas.Select(c => new Pecas
                {
                    Peca = c.Peca.Nome,
                    PecaId = c.PecaId,
                    Preco = c.Peca.Preco
                })));
        }
    }
}
