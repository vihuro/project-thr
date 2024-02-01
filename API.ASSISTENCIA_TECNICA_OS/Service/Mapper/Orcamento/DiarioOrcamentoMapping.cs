using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Orcamento
{
    public class DiarioOrcamentoMapping : Profile
    {
        public DiarioOrcamentoMapping()
        {
            CreateMap<InsertInformacaoDiarioDto, DiarioOrcamentoModel>()
                .ForMember(x => x.Informacao, map => map.MapFrom(src => src.Observacao))
                .ForMember(x => x.OrcamentoId, map => map.MapFrom(src => src.NumeroOrcamento))
                .ForMember(x => x.Tag, map => map.MapFrom(src => src.Tag))
                .ForMember(x => x.DataHoraApontamento, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioApontamentoId, map => map.MapFrom(src => src.UsuarioId));

            CreateMap<DiarioOrcamentoModel, ReturnDiarioOrcamentoDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Informacao, map => map.MapFrom(src => src.Informacao))
                .ForMember(x => x.NumeroOrcamento, map => map.MapFrom(src => src.OrcamentoId))
                .ForMember(x => x.Tag, map => map.MapFrom(src => src.Tag))
                .ForMember(x => x.DataHoraApontamento, map => map.MapFrom(src => src.DataHoraApontamento))
                .ForMember(x => x.Privado, map => map.MapFrom(src => src.Privado))
                .ForMember(x => x.UsuarioApontamentoApelido, map => map.MapFrom(src => src.UsuarioApontamento.Apelido))
                .ForMember(x => x.UsuarioApontamentoNome, map => map.MapFrom(src => src.UsuarioApontamento.Nome))
                .ForMember(x => x.UsuarioApontamentoId, map => map.MapFrom(src => src.UsuarioApontamento.Id));
        }
    }
}
