using API.ASSISTENCIA_TECNICA_OS.DTO.Client;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IClientInteService
    {
        Task<ReturnClientDto> Insert(InsertClientDto dto);
        Task<bool> DeleteAll();
        Task<List<ReturnClientDto>> GetAll();
        Task<ReturnClientDto> GetById(Guid id);
        Task<ReturnClientDto> UpdateCliente(UpdateClienteDto dto);
        Task<ReturnClientDto> GetByCodigoRadar(string codigoRadar);
    }
}
