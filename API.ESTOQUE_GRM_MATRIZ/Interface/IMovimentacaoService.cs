using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Movimentacao;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface IMovimentacaoService
    {
        Task<ReturnMovimentacao> Insert(UpdateMovimentacaoQuantidadeDto dto);
        Task<bool> DeleteAll();
        Task<ReturnMovimentacao> GetById(Guid id);
        Task<List<ReturnMovimentacao>> GetByMaterialId(int id);
        Task<List<ReturnMovimentacao>> GetAll();
    }
}
