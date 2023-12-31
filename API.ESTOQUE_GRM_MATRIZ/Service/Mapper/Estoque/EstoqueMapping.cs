﻿using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Local;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Models.Estoque;
using AutoMapper;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Estoque
{
    public class EstoqueMapping : Profile
    {
        public EstoqueMapping() 
        {
            CreateMap<InsertEstoqueDto, EstoqueModel>()
                .ForMember(x => x.Codigo, map => map.MapFrom(src => src.Codigo.ToUpper()))
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.Descricao.ToUpper()))
                .ForMember(x => x.Unidade, map => map.MapFrom(src => src.Unidade.ToUpper()))
                .ForMember(x => x.Quantidade, map => map.MapFrom(src => src.Quantidade))
                .ForMember(x => x.LocalArmazenagemId, map => map.MapFrom(src => src.LocalEstoqueId))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.UsuarioCadastroId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.DataHoraCadastro, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => true))
                .ForMember(x => x.DataFabricacao, map => map.MapFrom(src => src.DataFabricacao))
                .ForMember(x => x.Preco, map => map.MapFrom(src => src.Preco))
                .ForMember(x => x.ClienteUltimaCompra1, map => map.MapFrom(src => src.ClienteUltimaCompra1.ToUpper()))
                .ForMember(x => x.CodigoClienteUltimaCompra1, map => map.MapFrom(src => src.CodigoClienteUltimaCompra1.ToUpper()))
                .ForMember(x => x.ClienteUltimaCompra2, map => map.MapFrom(src => src.ClienteUltimaCompra2.ToUpper()))
                .ForMember(x => x.CodigoClienteUltimaCompra2, map => map.MapFrom(src => src.CodigoClienteUltimaCompra2.ToUpper()))
                .ForMember(x => x.ClienteUltimaCompra3, map => map.MapFrom(src => src.ClienteUltimaCompra3.ToUpper()))
                .ForMember(x => x.CodigoClienteUltimaCompra3, map => map.MapFrom(src => src.CodigoClienteUltimaCompra3.ToUpper()));

            CreateMap<EstoqueModel, ReturnEstoqueDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Codigo, map => map.MapFrom(src => src.Codigo))
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.Descricao))
                .ForMember(x => x.Unidade, map => map.MapFrom(src => src.Unidade))
                .ForMember(x => x.Quantidade, map => map.MapFrom(src => src.Quantidade))
                .ForMember(x => x.Ativo, map => map.MapFrom(src => src.Ativo))
                .ForMember(x => x.DataFabricao, map => map.MapFrom(src => src.DataFabricacao))
                .ForMember(x => x.Preco, map => map.MapFrom(src => src.Preco))
                .ForMember(x => x.ClienteUltimaCompra1, map => map.MapFrom(src => src.ClienteUltimaCompra1))
                .ForMember(x => x.CodigoClienteUltimaCompra1, map => map.MapFrom(src => src.CodigoClienteUltimaCompra1))
                .ForMember(x => x.ClienteUltimaCompra2, map => map.MapFrom(src => src.ClienteUltimaCompra2))
                .ForMember(x => x.CodigoClienteUltimaCompra2, map => map.MapFrom(src => src.CodigoClienteUltimaCompra2))
                .ForMember(x => x.ClienteUltimaCompra3, map => map.MapFrom(src => src.ClienteUltimaCompra3))
                .ForMember(x => x.CodigoClienteUltimaCompra3, map => map.MapFrom(src => src.CodigoClienteUltimaCompra3))
                .ForPath(x => x.LocalEstocagem, map => map.MapFrom(src => new ReturnLocaleStorageResume
                {
                    Guid = src.LocalArmazenagem.Id,
                    LocalEstocagem = src.LocalArmazenagem.Local
                }))
                .ForPath(x => x.TipoMaterial, map => map.MapFrom(src => new ReturnTypeMaterialResumeDto
                {
                    Id = src.TipoMaterial.Id,
                    Tipo = src.TipoMaterial.TipoMaterial
                }))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UsertDateTime
                {
                    Apelido = src.UsuarioCadastro.Apelido,
                    Nome = src.UsuarioCadastro.Nome,
                    Id = src.UsuarioCadastro.Id,
                    DataHora = src.DataHoraCadastro
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UsertDateTime
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    Nome = src.UsuarioAlteracao.Nome,
                    Id = src.UsuarioAlteracao.Id,
                    DataHora = src.DataHoraAlteracao
                }))
                .ForPath(x => x.Substitutos, map => map.MapFrom(src => src.Substituos.Select(c => new ReturnSubstitutosResumeDto
                {
                    SubstitutoId = c.SubstitutoId,
                    ProdutoId = c.MaterialEstoqueId,
                    Codigo = c.Substituto.Codigo,
                    Descricao = c.Substituto.Descricao,
                    Unidade = c.Substituto.Unidade,
                    Quantidade = c.Substituto.Quantidade,
                    LocalEstocagem = c.Substituto.LocalArmazenagem.Local,
                    TipoMaterial = c.Substituto.TipoMaterial.TipoMaterial
                })));


        }
    }
}
