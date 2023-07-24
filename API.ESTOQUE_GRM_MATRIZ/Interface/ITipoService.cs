using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;

namespace API.ESTOQUE_GRM_MATRIZ.Interface
{
    public interface ITipoService
    {
        Task<ReturnType> Insert(InsertTypeDto dto);
        Task<List<ReturnType>> GetAll();
        Task<ReturnType> GetById(Guid id);
        Task<bool> DelteAll();

    }
}
