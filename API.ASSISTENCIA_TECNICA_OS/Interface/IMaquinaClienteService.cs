using API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IMaquinaClienteService
    {
        Task<ReturnMaquinaClienteDto> UpdateMaquinaInCliente(InsertMaquinaInClientDto dto);
        Task<bool> DeleteMaquinaInCliente(Guid id);
    }
}
