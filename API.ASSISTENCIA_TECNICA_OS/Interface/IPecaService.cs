using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IPecaService
    {
        Task<ReturnPecasDto> GetWithoutSkip();
        Task<ReturnPecasDto> Update(UpdatePecaDto dto);
        Task<ReturnPecasDto> GetAll(int skip, int take);
        Task<ReturnPecasDto> GetById(Guid id);
        Task<bool> DeleteAll();
        Task<ReturnPecasDto> InsertPecas(Guid idUsuario);
        Task<ReturnPecasDto> GetNotRegister();
        Task<ReturnPecasDto> GetRadar();
        Task<ReturnPecasDto> GetWithFilter(FilterPecasDto dto,int skip, int take);
    }
}
