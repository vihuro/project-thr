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
                .ForMember(x => x.Status, map => map.MapFrom(src => 0));

            CreateMap<MaquinaClienteModel, ReturnMaquinaClienteDto>()
                .ForMember(x => x.Id, map => map.MapFrom(src => src.Id))
                .ForPath(x => x.Cliente, map => map.MapFrom(src => new ClienteDto
                {
                    ClienteId = src.ClienteId,
                    Cnpj = src.Cliente.Cnpj,
                    CodigoRadar = src.Cliente.CodigoRadar,
                    //Endereco = src.Cliente.Endereco,
                    NomeCliente = src.Cliente.Nome
                }))
                .ForPath(x => x.Maquina, map => map.MapFrom(src => new MaquinaDto
                {
                    MaquinaId = src.MaquinaId,
                    TipoMaquina = src.Maquina.DescricaoMaquina
                    
                }));
        }

    }

}
