using API.ASSISTENCIA_TECNICA_OS.DTO.Client;
using API.ASSISTENCIA_TECNICA_OS.Model.Client;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Mapper.Client
{
    public class ClientMapping :Profile
    {
        public ClientMapping() 
        {
            CreateMap<InsertClientDto, ClientModel>()
                .ForMember(x => x.Endereco, map => map.MapFrom(src => src.Endereco))
                .ForMember(x => x.NomeContatoClient, map => map.MapFrom(src => src.NomeContatoCliente))
                .ForMember(x => x.ContatoTelefone, map => map.MapFrom(src => src.ContatoTelefone))
                .ForMember(x => x.Cnpj, map => map.MapFrom(src => src.Cnpj))
                .ForMember(x => x.CodigoRadar, map => map.MapFrom(src => src.CodigoRadar));

            CreateMap<ClientModel, ReturnClientDto>()
                .ForMember(x => x.IdCliente, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Endereco, map => map.MapFrom(src => src.Endereco))
                .ForMember(x => x.ContatoNome, map => map.MapFrom(src => src.NomeContatoClient))
                .ForMember(x => x.ContatoTelefone, map => map.MapFrom(src => src.ContatoTelefone))
                .ForMember(x => x.Cnpj, map => map.MapFrom(src => src.Cnpj)).
                ForMember(x => x.CodigoRadar, map => map.MapFrom(src => src.CodigoRadar));
        }
    }
}
