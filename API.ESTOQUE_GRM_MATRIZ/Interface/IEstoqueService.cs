using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface IEstoqueService
    {
        Task<ReturnEstoqueDto> Insert(InsertEstoqueDto dto);
        Task<List<ReturnEstoqueDto>> GetAll();
        Task<ReturnEstoqueDto> GetById(Guid id);
        Task<bool> DeleteAll();
    }
}
