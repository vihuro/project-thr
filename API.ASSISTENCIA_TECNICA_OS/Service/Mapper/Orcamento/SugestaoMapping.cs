using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento.Sugestao;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Orcamento
{
    public class SugestaoMapping : Profile
    {
        public SugestaoMapping()
        {
            CreateMap<InsertSugestaoDto, SugestacaoManutencaoModel>()
                .ForMember(x => x.SugestacaoManutencao, map => map.MapFrom(src => src.DescricaoSugestao))
                .ForMember(x => x.DataHoraSugestacao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioSugestacaoId, map => map.MapFrom(src => src.UsuarioSugestaoId))
                .ForMember(x => x.MaquinaId, map => map.MapFrom(src => src.MaquinaSugestaoId));

            CreateMap<SugestacaoManutencaoModel, ReturnSugestaoDto>()
                .ForMember(x => x.SugestaoManutencao, map => map.MapFrom(src => src.SugestacaoManutencao))
                .ForMember(x => x.Status, map => map.MapFrom(src => ValidateStatus(src)));
        }

        private static string ValidateStatus(SugestacaoManutencaoModel src)
        {
            if(src.StatusSugestacao != "")
                return src.StatusSugestacao;

            var dateTimeNow = DateTime.UtcNow;
            var diferenca = src.DataCobranca - dateTimeNow;

            switch (diferenca.TotalDays)
            {
                case > 1:
                    return "EM DIA";
                case <= 0:
                    return "ATRASADO";
                default:
                    return "ainda não";
            }

        }
    }
}
