using API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IMaquinaClienteService
    {
        Task<ReturnMaquinaClienteDto> UpdateMaquinaInCliente(InsertMaquinaInClientDto dto);
        Task<ReturnMaquinaClienteDto> GetByMaquinaIndCliente(Guid id);
        Task<bool> DeleteMaquinaInCliente(Guid id);
        Task<bool> MaquinaAtribuida(Guid maquinaId);
        Task<ReturnMaquinaClienteDto> UpdateStatusForLiberada(UpdateStatusMaquina dto);
        Task<ReturnMaquinaClienteDto> UpdateStatusForAguardandoOrcamento(UpdateStatusMaquina dto);
        Task<ReturnMaquinaClienteDto> UpdateStatusForAguardandoAprovacao(UpdateStatusMaquina dto);
        Task<ReturnMaquinaClienteDto> UpdateStatusForEmManutencao(UpdateStatusMaquina dto);
    }
}
