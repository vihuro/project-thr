using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Local;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Movimentacao;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Models.Estoque;
using AutoMapper;

namespace API.ESTOQUE_GRM_MATRIZ.Service.Mapper.Movimentacao
{
    public class MovimentacaoMapping : Profile
    {
        public MovimentacaoMapping() 
        {
            CreateMap<MovimentacaoModel, ReturnMovimentacao>()
                .ForMember(x => x.MovimentacaoId, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.QuantidadeMovimentacao, map => map.MapFrom(src => src.QuantidadeMovimentada))
                .ForMember(x => x.QuantidadeOrigem, map => map.MapFrom(src => src.QuantidadeOrigem))
                .ForMember(x => x.NovaQuantidade, map => map.MapFrom(src => src.QuantidadeDestino))
                .ForMember(x => x.Destino, map => map.MapFrom(src => src.Destino))
                .ForPath(x => x.UsuarioMovimentacao, map => map.MapFrom(src => new UsertDateTime
                {
                    Apelido = src.UsuarioMovimentacao.Apelido,
                    Nome = src.UsuarioMovimentacao.Nome,
                    DataHora = src.DataHoraMovimentacao,
                    Id = src.UsuarioMovimentacao.Id
                }))
                .ForPath(x => x.MaterialMovimentado, map => map.MapFrom(src => new ReturnEstoqueResumidoDto
                {
                    Codigo = src.Material.Codigo,
                    Descricao = src.Material.Descricao,
                    Quantidade = src.Material.Quantidade,
                    Unidade = src.Material.Unidade,
                    Id = src.Material.Id,
                    LocalEstocagem = new ReturnLocaleStorageResume
                    {
                        LocalEstocagem = src.Material.LocalArmazenagem.Local,
                        Guid = src.Material.LocalArmazenagem.Id,
                    },
                    Tipo = new ReturnTypeMaterialResumeDto
                    {
                        Tipo = src.Material.TipoMaterial.TipoMaterial,
                        Id = src.Material.TipoMaterial.Id
                    }

                }));
        }
    }
}
