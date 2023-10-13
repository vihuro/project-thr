using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface ISubstitutosService
    {
        Task<ReturnSubstitutoDto> UpdateSubstituto(UpdateSubstitutoDto dto);
        Task<List<ReturnSubstitutoDto>> GetAll();
        Task<ReturnSubstitutoDto> GetById(int id);
        Task<bool> DeleteAll();
        Task<bool> DeleteById(DeleteSubstitutoById dto);
    }
}
