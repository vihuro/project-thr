using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Local;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Models.Substituto;
using AutoMapper;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Substituto
{
    public class SubstitutoMapping : Profile
    {
        public SubstitutoMapping() 
        {
            CreateMap<UpdateSubstitutoDto, SubstitutoModel>()
                .ForMember(x => x.SubstitutoId, map => map.MapFrom(src => src.SubstitutoId))
                .ForMember(x => x.MaterialEstoqueId, map => map.MapFrom(src => src.ProdutoId))
                .ForMember(x => x.UsuarioAlteracaoId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.UsuarioCadatroId, map => map.MapFrom(src => src.UsuarioId))
                .ForMember(x => x.DataHoraAlteracao, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.DataHoraCadatro, map => map.MapFrom(src => DateTime.UtcNow));

            CreateMap<SubstitutoModel, ReturnSubstitutoDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.CodigoId, map => map.MapFrom(src => src.MaterialEstoque.Id))
                .ForMember(x => x.Codigo, map => map.MapFrom(src => src.MaterialEstoque.Codigo))
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.MaterialEstoque.Descricao))
                .ForMember(x => x.Unidade, map => map.MapFrom(src => src.MaterialEstoque.Unidade))
                .ForMember(x => x.Quantidade, map => map.MapFrom(src => src.MaterialEstoque.Quantidade))
                .ForPath(x => x.LocalEstocagem, map => map.MapFrom(src => new ReturnLocaleStorageResume
                {
                    LocalEstocagem = src.MaterialEstoque.LocalArmazenagem.Local,
                    Guid = src.MaterialEstoque.LocalArmazenagem.Id
                }))
                .ForPath(x => x.Tipo, map => map.MapFrom(src => new ReturnTypeMaterialResumeDto
                {
                    Tipo = src.MaterialEstoque.TipoMaterial.TipoMaterial,
                    Id = src.MaterialEstoque.TipoMaterial.Id
                }))
                .ForPath(x => x.Cadastro, map => map.MapFrom(src => new UsertDateTime
                {
                    Apelido = src.UsuarioCadatro.Apelido,
                    Nome = src.UsuarioCadatro.Nome,
                    Id = src.UsuarioCadatro.Id,
                    DataHora = src.DataHoraCadatro
                }))
                .ForPath(x => x.Alteracao, map => map.MapFrom(src => new UsertDateTime
                {
                    Apelido = src.UsuarioAlteracao.Apelido,
                    Nome = src.UsuarioAlteracao.Nome,
                    Id = src.UsuarioAlteracao.Id,
                    DataHora = src.DataHoraAlteracao
                }))
                .ForPath(x => x.Substituto, map => map.MapFrom(src => new ReturnEstoqueResumidoDto
                {
                    Codigo = src.Substituto.Codigo,
                    Descricao = src.Substituto.Descricao,
                    Quantidade = src.Substituto.Quantidade,
                    Id = src.Substituto.Id,
                    Unidade = src.Substituto.Unidade,
                    LocalEstocagem = new ReturnLocaleStorageResume
                    {
                        LocalEstocagem = src.Substituto.LocalArmazenagem.Local,
                        Guid = src.Substituto.LocalArmazenagem.Id
                    },
                    Tipo = new ReturnTypeMaterialResumeDto
                    {
                        Tipo = src.Substituto.TipoMaterial.TipoMaterial,
                        Id = src.Substituto.TipoMaterial.Id
                    }
                })) ;
        }
    }
}
