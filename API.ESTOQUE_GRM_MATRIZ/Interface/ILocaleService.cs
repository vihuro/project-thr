using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface ILocaleService
    {
        Task<ReturnLocaleDto> Insert(InsertLocale dto);
        Task<List<ReturnLocaleDto>> GetAll();
        Task<ReturnLocaleDto> GetById(Guid id);
        Task<bool> DeleteAll();
    }
}
