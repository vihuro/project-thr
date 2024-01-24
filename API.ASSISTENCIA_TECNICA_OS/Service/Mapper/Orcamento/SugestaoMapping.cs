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
                .ForMember(x => x.DataHoraSugestao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.DataCobranca, map => map.MapFrom(src => src.DataCobranca))
                .ForMember(x => x.UsuarioSugestaoId, map => map.MapFrom(src => src.UsuarioSugestaoId))
                .ForMember(x => x.MaquinaClienteId, map => map.MapFrom(src => src.MaquinaSugestaoId));

            CreateMap<SugestacaoManutencaoModel, ReturnSugestaoDto>()
                .ForMember(x => x.SugestaoManutencao, map => map.MapFrom(src => src.SugestacaoManutencao))
                .ForMember(x => x.DataCobranca, map => map.MapFrom(src => src.DataCobranca))
                .ForMember(x => x.MaquinaSugerida, map => map.MapFrom(src => new MaquinaSugerida
                {
                    NumeroSerie = src.MaquinaCliente.Maquina.NumeroSerie,
                    CodigoMaquina = src.MaquinaCliente.Maquina.CodigoMaquina,
                    DescricaoMaquina = src.MaquinaCliente.Maquina.DescricaoMaquina,
                    MaquinaId = src.MaquinaCliente.Maquina.Id
                }))
                .ForPath(x => x.UsuarioSugestao, map => map.MapFrom(src => new CriacaoSugestacaoManutencao
                {
                    Apelido = src.UsuarioSugestao.Apelido,
                    Nome = src.UsuarioSugestao.Nome,
                    DataHoraCriacaoSugestacao = src.DataHoraSugestao,
                    UsuarioId = src.UsuarioSugestao.Id
                }))
                .ForMember(x => x.Status, map => map.MapFrom(src => ValidateStatus(src)));
        }

        private static string ValidateStatus(SugestacaoManutencaoModel src)
        {

            if (src.StatusSugestao == EStatusSugestacao.FINALIZADO)
                return "FINALIZADO";

            var dateTimeNow = DateTime.UtcNow;
            var diferenca = src.DataCobranca - dateTimeNow;

            if (DateTime.UtcNow.Day == src.DataCobranca.Day) return "HOJE";

            switch (diferenca.TotalDays)
            {
                case >= 1:
                    return "EM DIA";
                case 0:
                    return "HOJE";
                case < 0:
                    return "ATRASADO";
                default:
                    return "EM DIA";
            }

        }
    }
}
