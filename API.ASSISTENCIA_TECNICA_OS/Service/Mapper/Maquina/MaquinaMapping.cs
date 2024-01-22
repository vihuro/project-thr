using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Maquina
{
    public class MaquinaMapping : Profile
    {
        public MaquinaMapping() 
        {
            CreateMap<InsertMaquinaDto, MaquinaModel>()
                .ForMember(x => x.Ativo, map => map.MapFrom(src => true))
                .ForMember(x => x.Atribuida, map => map.MapFrom(src => false))
                .ForMember(x => x.DescricaoMaquina, map => map.MapFrom(src => src.DescricaoMaquina.ToUpper()))
                .ForMember(x => x.NumeroSerie, map => map.MapFrom(src => src.NumeroSerie.ToUpper()))
                .ForMember(x => x.CodigoMaquina, map => map.MapFrom(src => src.CodigoMaquina.ToUpper()))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.Pecas, map => map.MapFrom(src => src.Pecas.Select(c => new PecasPorMaquinaModel
                {
                    PecaId = c.IdPeca,

                })));


            CreateMap<MaquinaModel, ReturnMaquinaComPecasDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.CodigoMaquina, map => map.MapFrom(src => src.CodigoMaquina))
                .ForMember(x => x.DescricaoMaquina, map => map.MapFrom(src => src.DescricaoMaquina))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => src.Ativo))
                .ForMember(x => x.NumeroSerie, map => map.MapFrom(src => src.NumeroSerie))
                .ForMember(x => x.Atribuida, map => map.MapFrom(src => src.Atribuida))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UserDto
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome = src.UsuarioCadastro.Nome,
                    UsuarioId = src.UsuarioCadastro.Id,
                    DataHora = src.DataHoraCadastro
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UserDto
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    Nome = src.UsuarioAlteracao.Nome,
                    UsuarioId = src.UsuarioAlteracao.Id,
                    DataHora = src.DataHoraAlteracao
                }))
                .ForPath(x => x.Pecas, map => map.MapFrom(src => src.Pecas.Select(c => new PecaMaquinaDto
                {
                    CodigoRadar = c.Peca.CodigoRadar,
                    DescricaoPeca = c.Peca.Descricao,
                    PecaId = c.PecaId,
                    Preco = c.Peca.Preco
                })));
        }
    }
}
