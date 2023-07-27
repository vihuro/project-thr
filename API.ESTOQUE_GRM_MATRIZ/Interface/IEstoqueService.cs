using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface IEstoqueService
    {
        Task<ReturnEstoqueDto> Insert(InsertEstoqueDto dto);
        Task<List<ReturnEstoqueDto>> GetAll();
        Task<ReturnEstoqueDto> GetById(Guid id);
        Task<bool> DeleteAll();
        Task<ReturnEstoqueDto> UpdateQuantidade(UpdateQuantidadeDto dto);
        Task<List<ReturnEstoqueDto>> UpdateQuantidadeZero();
    }
}
