using API.ASSISTENCIA_TECNICA_OS.DTO.OrdemServico;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.OrdemServico;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.OrdemServico
{
    public class OrdemServicoMapping : Profile
    {
        public OrdemServicoMapping() 
        {
            CreateMap<InsertOrdemDto, OrdemServicoModel>()
                .ForMember(x => x.Status, map => map.MapFrom(src => "ABERTO"))
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.Descricao))
                .ForPath(x => x.MaquinaPorOs, map => map.MapFrom(src => src.Maquinas.Select(c => new PecasPorMaquinaEOrdemModel
                {
                    MaquinaId = c.IdMaquina
                })));

            CreateMap<OrdemServicoModel, ReturnOrdemDto>()
                .ForMember(x => x.Descricao, map => map.MapFrom(src => src.Descricao))
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Maquinas, map => map.MapFrom(src => GroupAndMapMaquinas(src.MaquinaPorOs)));

        }
        private static List<ReturnMaquinaDto> GroupAndMapMaquinas(List<PecasPorMaquinaEOrdemModel> maquinas)
        {
            var groupedMaquinas = maquinas
                .GroupBy(m => m.MaquinaId)
                .Select(group =>
                {
                    var firstMaquina = group.First().Maquina;
                    var pecas = group.Select(p => new Pecas
                    {
                        Peca = p.Peca.Nome,
                        PecaId = p.PecaId,
                        Conserto = p.Conserto,
                        Troca = p.Troca,
                        EnderecoImagem = p.Peca.EnderecoImagem[0]
                    }).ToList();

                    return new ReturnMaquinaDto
                    {
                        Maquina = firstMaquina.TipoMaquina,
                        MaquinaId = firstMaquina.Id,
                        PecasDaMaquina = pecas
                    };
                })
                .ToList();

            return groupedMaquinas;
        }
    }
}
