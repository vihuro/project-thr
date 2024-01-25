using API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.MaquinaInCliente
{
    public class MaquinaInClienteMapping : Profile
    {
        public MaquinaInClienteMapping()
        {
            CreateMap<InsertMaquinaInClientDto, MaquinaClienteModel>()
                .ForMember(x => x.ClienteId, map => map.MapFrom(src => src.ClienteId))
                .ForMember(x => x.MaquinaId, map => map.MapFrom(src => src.MaquinaId))
                .ForMember(x => x.DataSugestaoRetorno, map => map.MapFrom(src => src.DataSugeridaRetorno))
                .ForMember(x => x.TipoAquisicao, map => map.MapFrom(src => src.TipoAquisicao))
                .ForMember(x => x.Status, map => map.MapFrom(src => 0));

            CreateMap<MaquinaClienteModel, ReturnMaquinaClienteDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForPath(x => x.Cliente, map => map.MapFrom(src => new ClienteDto
                {
                    ClienteId = src.ClienteId,
                    Cnpj = src.Cliente.Cnpj,
                    CodigoRadar = src.Cliente.CodigoRadar,
                    CEP = src.Cliente.CEP,
                    Estado = src.Cliente.Estado,
                    Cidade = src.Cliente.Cidade,
                    Regiao = src.Cliente.Regiao,
                    NomeRua = src.Cliente.Rua,
                    NumeroEstabelecimento = src.Cliente.NumeroEstabelecimento,
                    Complemento = src.Cliente.Complemento,
                    ContatoNomeCliente = src.Cliente.NomeContatoClient,
                    ContatoTelefoneCliente = src.Cliente.ContatoTelefone,
                    NomeCliente = src.Cliente.Nome
                }))
                .ForPath(x => x.Maquina, map => map.MapFrom(src => new MaquinaDto
                {
                    MaquinaId = src.MaquinaId,
                    CodigoMaquina = src.Maquina.CodigoMaquina,
                    DescricaoMaquina = src.Maquina.DescricaoMaquina,
                    DataSugestaoRetorno = src.DataSugestaoRetorno,
                    TipoAquisicao = ValidateTypeAquisicao(src.TipoAquisicao),
                    Pecas = src.Maquina.Pecas.Select(c => new ReturnPecasInMaquinaInClienteDto
                    {
                        CodigoPeca = c.Peca.CodigoRadar,
                        DescricaoPeca = c.Peca.Descricao,
                        PecaId = c.Peca.Id,
                        Preco = c.Peca.Preco
                    }).ToList()

                }));
        }
        private static string ValidateTypeAquisicao(ETipoAquisicao tipoAquisicao)
        {
            switch (tipoAquisicao)
            {
                case ETipoAquisicao.VENDA:
                    return "VENDA";
                case ETipoAquisicao.EMPRESTIMO:
                    return "EMPRÉSTIMO";
                default:
                    return "VENDA";
            }
        }

    }

}
