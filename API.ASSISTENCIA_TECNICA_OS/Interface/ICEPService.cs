using API.ASSISTENCIA_TECNICA_OS.DTO.CEP;
using Microsoft.AspNetCore.Mvc;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface ICEPService
    {
        Task<ReturnCEPDto> Get(int cep);
    }
}
