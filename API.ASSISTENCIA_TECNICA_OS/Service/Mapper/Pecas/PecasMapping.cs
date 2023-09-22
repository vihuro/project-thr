using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Pecas
{
    public class PecasMapping : Profile
    {
        public PecasMapping()
        {
            CreateMap<InsertPecaDto, PecasModel>()
                .ForMember(x => x.CodigoRadar, map => map.MapFrom(src => src.CodigoRadar.ToUpper()))
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.Descricao.ToUpper()))
                .ForMember(x => x.Preco, map => map.MapFrom(src => src.Preco))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.EnderecoImagem, map => map.MapFrom(src => src.EnderecoImagem));

            CreateMap<PecasModel, ReturnPecasDto>()
                .ForMember(x => x.CodigoRadar, map => map.MapFrom(src => src.CodigoRadar))
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.Descricao))
                .ForMember(x => x.Preco, map => map.MapFrom(src => src.Preco))
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.EnderecoImagem, map => map.MapFrom(src => src.EnderecoImagem))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UsuarioDataHora
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    IdUsuario = src.UsuarioCadastro.Id,
                    Nome = src.UsuarioCadastro.Nome,
                    DataHora = src.DataHoraCadastro
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UsuarioDataHora
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    IdUsuario = src.UsuarioAlteracao.Id,
                    Nome = src.UsuarioAlteracao.Nome,
                    DataHora = src.DataHoraAlteracao
                }));


        }
    }
}
