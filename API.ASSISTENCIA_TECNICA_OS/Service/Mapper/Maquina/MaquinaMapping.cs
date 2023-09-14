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
                .ForMember(x => x.Atribuida, map => map.MapFrom(src => false))
                .ForMember(x => x.TipoMaquina, map => map.MapFrom(src => src.TipoMaquina.ToUpper()))
                .ForMember(x => x.NumeroSerie, map => map.MapFrom(src => src.NumeroSerie.ToUpper()))
                .ForMember(x => x.CodigoMaquina, map => map.MapFrom(src => src.CodigoMaquina.ToUpper()))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UserId));


            CreateMap<MaquinaModel, ReturnMaquinaComPecasDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Codigo, map => map.MapFrom(src => src.CodigoMaquina))
                .ForMember(x => x.TipoMaquina, map => map.MapFrom(src => src.TipoMaquina))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => src.Ativo))
                .ForMember(x => x.NumeroSerie, map => map.MapFrom(src => src.NumeroSerie))
                .ForMember(x => x.Atribuida, map => map.MapFrom(src => src.Atribuida))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UserDto
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome = src.UsuarioCadastro.Nome,
                    UserId = src.UsuarioCadastro.Id,
                    DataHora = src.DataHoraCadastro
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UserDto
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    Nome = src.UsuarioAlteracao.Nome,
                    UserId = src.UsuarioAlteracao.Id,
                    DataHora = src.DataHoraAlteracao
                }));
        }
    }
}
