using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface IEstoqueService
    {
        Task<ReturnEstoqueDto> Insert(InsertEstoqueDto dto);
        Task<List<ReturnEstoqueDto>> GetAll();
        Task<List<ReturnEstoqueDto>> GetAllForBI();
        Task<ReturnEstoqueDto> GetById(int id);
        Task<bool> DeleteAll();
        Task<ReturnEstoqueDto> UpdateQuantidade(UpdateQuantidadeDto dto);
        Task<List<ReturnEstoqueDto>> GetWithoutSubstituto(int id);
        Task<List<ReturnEstoqueDto>> UpdateQuantidadeZero();
        Task<ReturnEstoqueDto> UpdateDateTimeChange(int produtoId, Guid usuarioId);
        Task<ReturnEstoqueDto> UpdateQuantidadeOrUnidade(UpdateQuantidadeOrUnidadeDto dto);
        Task<ReturnEstoqueDto> UpdatePreco(UpdatePrecoDto dto);
        Task<ReturnEstoqueDto> UpdateUltimoClienteCompra(UpdateUltimoClienteCompraDto dto);
    }
}
