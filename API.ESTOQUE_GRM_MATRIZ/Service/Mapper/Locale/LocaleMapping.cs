using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Models.Estoque;
using AutoMapper;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Locale
{
    public class LocaleMapping : Profile
    {
        public LocaleMapping()
        {
            CreateMap<InsertLocale, LocalArmazenagemModel>()
                .ForMember(x => x.Local, map => map.MapFrom(src => src.Local.ToUpper()))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => true))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow));

            CreateMap<LocalArmazenagemModel, ReturnLocaleDto>()
                .ForMember(x => x.Ativo, map => map.MapFrom(src => src.Ativo))
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Local, map => map.MapFrom(src => src.Local))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UsertDateTime
                {
                    Nome = src.UsuarioCadastro.Nome,
                    Apelido = src.UsuarioCadastro.Apelido,
                    DataHora = src.DataHoraCadastro,
                    Id = src.UsuarioCadastro.Id
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UsertDateTime
                {
                    Nome = src.UsuarioAlteracao.Nome,
                    Apelido = src.UsuarioAlteracao.Apelido,
                    DataHora = src.DataHoraAlteracao,
                    Id = src.UsuarioAlteracao.Id
                }));
        }
    }
}
