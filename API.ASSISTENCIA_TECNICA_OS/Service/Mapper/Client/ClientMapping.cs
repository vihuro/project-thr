using API.ASSISTENCIA_TECNICA_OS.DTO.Client;
using API.ASSISTENCIA_TECNICA_OS.Model.Client;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Client
{
    public class ClientMapping : Profile
    {
        public ClientMapping()
        {
            CreateMap<InsertClientDto, ClientModel>()
                .ForMember(x => x.CEP, map => map.MapFrom(src => src.Cep))
                .ForMember(x => x.Estado, map => map.MapFrom(src => src.Estado))
                .ForMember(x => x.Cidade, map => map.MapFrom(src => src.Cidade))
                .ForMember(x => x.Regiao, map => map.MapFrom(src => src.Regiao))
                .ForMember(x => x.Rua, map => map.MapFrom(src => src.Rua))
                .ForMember(x => x.Complemento, map => map.MapFrom(src => src.Complemento))
                .ForMember(x => x.NumeroEstabelecimento, map => map.MapFrom(src => src.NumeroEstabelecimento))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome.ToUpper()))
                .ForMember(x => x.NomeContatoClient, map => map.MapFrom(src => src.NomeContatoCliente.ToUpper()))
                .ForMember(x => x.ContatoTelefone, map => map.MapFrom(src => src.ContatoTelefone))
                .ForMember(x => x.Cnpj, map => map.MapFrom(src => src.Cnpj))
                .ForMember(x => x.CodigoRadar, map => map.MapFrom(src => src.CodigoRadar.ToUpper()))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.Maquinas, map => map.MapFrom(src => src.Maquinas.Select(c => new MaquinaClienteModel
                {
                    MaquinaId = c.MaquinaId,
                    Status = StatusMaquinaClienteModel.LIBERADA,
                    DataSugestaoRetorno = Convert.ToDateTime(c.DataSugestaoRetorno).ToUniversalTime(),
                    TipoAquisicao = TipoAquisicao(c.TipoAquisicao)
                })));

            CreateMap<ClientModel, ReturnClientDto>()
                .ForMember(x => x.IdCliente, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Nome, map => map.MapFrom(src => src.Nome))
                .ForMember(x => x.Cep, map => map.MapFrom(src => src.CEP))
                .ForMember(x => x.Estado, map => map.MapFrom(src => src.Estado))
                .ForMember(x => x.Cidade, map => map.MapFrom(src => src.Cidade))
                .ForMember(x => x.Regiao, map => map.MapFrom(src => src.Regiao))
                .ForMember(x => x.Rua, map => map.MapFrom(src => src.Rua))
                                .ForMember(x => x.Complemento, map => map.MapFrom(src => src.Complemento))
                .ForMember(x => x.NumeroEstabelecimento, map => map.MapFrom(src => src.NumeroEstabelecimento))
                .ForMember(x => x.ContatoNome, map => map.MapFrom(src => src.NomeContatoClient))
                .ForMember(x => x.ContatoTelefone, map => map.MapFrom(src => src.ContatoTelefone))
                .ForMember(x => x.Cnpj, map => map.MapFrom(src => src.Cnpj))
                .ForMember(x => x.CodigoRadar, map => map.MapFrom(src => src.CodigoRadar))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UsuarioDto
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    UsuarioId = src.UsuarioCadastro.Id,
                    Nome = src.UsuarioCadastro.Nome,
                    DataHora = src.DataHoraCadastro
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UsuarioDto
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    UsuarioId = src.UsuarioAlteracao.Id,
                    Nome = src.UsuarioAlteracao.Nome,
                    DataHora = src.DataHoraAlteracao
                }))
                .ForPath(x => x.MaquinaCliente, map => map.MapFrom(src => src.Maquinas.Select(c => new MaquinaClienteDto
                {
                    Id = c.Id,
                    MaquinaId = c.MaquinaId,
                    CodigoMaquina = c.Maquina.CodigoMaquina,
                    NumeroSerie = c.Maquina.NumeroSerie,
                    DescricaoMaquina = c.Maquina.DescricaoMaquina,
                    Status = GetFormattedStatus(c.Status),
                    DataSugestaoRetorno = c.DataSugestaoRetorno,
                    TipoAquisicao = TipoAquisicaoString(c.TipoAquisicao)
                })));

        }
        public static string GetFormattedStatus(StatusMaquinaClienteModel status)
        {
            switch (status)
            {
                case StatusMaquinaClienteModel.LIBERADA:
                    return "Liberada";
                case StatusMaquinaClienteModel.AGUARDANDO_ORCAMENTO:
                    return "Aguardando Orçamento";
                case StatusMaquinaClienteModel.AGUARDANDO_APROVACAO:
                    return "Aguardando Aprovação";
                case StatusMaquinaClienteModel.EM_MANUTENCAO:
                    return "Em Manutenção";
                default:
                    return "Status Desconhecido";
            }
        }

        private static string TipoAquisicaoString(ETipoAquisicao tipoAquisicao)
        {
            switch (tipoAquisicao)
            {
                case ETipoAquisicao.EMPRESTIMO:
                    return "EMPRÉSTIMO";
                default:
                    return "VENDA";
            }
        }
        private static ETipoAquisicao TipoAquisicao(int tipoAquisicaoDto)
        {
            switch (tipoAquisicaoDto)
            {
                case 1:
                    return ETipoAquisicao.EMPRESTIMO;
                default:
                    return ETipoAquisicao.VENDA;
            }
        }
    }
}
