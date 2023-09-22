﻿using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Orcamento
{
    public class OrcamentoMapping : Profile
    {
        public OrcamentoMapping() 
        {
            CreateMap<InsertOrcamentoDto, OrcamentoModel>()
                .ForMember(x => x.DescricaoServico, map => map.MapFrom(src => src.DescricaoServico))
                .ForMember(x => x.ValorOrcamento, map => map.MapFrom(src => src.ValorOrcamento))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UserId))
                .ForMember(x => x.MaquinaId, map => map.MapFrom(src => src.MaquinaId));

            CreateMap<OrcamentoModel, ReturnOrcamentoDto>()
                .ForMember(x => x.NumeroOrcamento, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.DescricaoServico, map => map.MapFrom(src => src.DescricaoServico))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UserOrcamentoDto
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome = src.UsuarioCadastro.Nome,
                    DataHora = src.DataHoraCadastro,
                    UserId = src.UsuarioCadastro.Id
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UserOrcamentoDto
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    Nome = src.UsuarioAlteracao.Nome,
                    DataHora = src.DataHoraAlteracao,
                    UserId = src.UsuarioAlteracao.Id
                }))
                .ForPath(x => x.Status, map => map.MapFrom(src => src.Status.Select(c => new StatusOrcamentoDto
                {
                    Status = c.Status.Status,
                    StatusId = c.StatusId
                })))
                .ForPath(x => x.Maquina, map => map.MapFrom(src => new MaquinaOrcamentoDto
                {
                    CodigoMaquina = src.MaquinaCliente.Maquina.CodigoMaquina,
                    DescricaoMaquina = src.MaquinaCliente.Maquina.DescricaoMaquina,
                    MaquinaId = src.MaquinaCliente.Maquina.Id,
                    NumeroSerie = src.MaquinaCliente.Maquina.NumeroSerie,
                    Pecas = src.Pecas.Select(c => new PecasMaquinaOrcamentoDto
                    {
                        Troca = c.Troca,
                        Conserto = c.Conserto,
                        CodigoPeca = c.Peca.CodigoRadar,
                        DescricaoPeca = c.Peca.Descricao,
                        EnderecoImagem = c.Peca.EnderecoImagem,
                        PecaId = c.Peca.Id,
                        Preco = c.Peca.Preco
                    }).ToList()
                    /*Pecas = src.MaquinaCliente.Maquina.Pecas.Select(c => new PecasMaquinaOrcamentoDto
                    {
                        CodigoPeca = c.Peca.CodigoRadar,
                        DescricaoPeca = c.Peca.Descricao,
                        EnderecoImagem = c.Peca.EnderecoImagem,
                        PecaId = c.Peca.Id,
                        Preco = c.Peca.Preco
                    }).ToList()*/
                }))
                .ForPath(x => x.Cliente, map => map.MapFrom(src => new ClienteOrcamentoDto
                {
                    CEP = src.MaquinaCliente.Cliente.CEP,
                    Cidade = src.MaquinaCliente.Cliente.Cidade,
                    Cnpj = src.MaquinaCliente.Cliente.Cnpj,
                    CodigoRadar = src.MaquinaCliente.Cliente.CodigoRadar,
                    ContatoNomeCliente = src.MaquinaCliente.Cliente.NomeContatoClient,
                    ContatoTelefoneCliente = src.MaquinaCliente.Cliente.ContatoTelefone,
                    Estado = src.MaquinaCliente.Cliente.Estado,
                    NomeCliente = src.MaquinaCliente.Cliente.Nome,
                    NumeroEstabelecimento = src.MaquinaCliente.Cliente.NumeroEstabelecimento,
                    Regiao = src.MaquinaCliente.Cliente.Regiao,
                    Rua = src.MaquinaCliente.Cliente.Rua
                }));
        }
    }
}
