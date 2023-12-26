using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento.Sugestao;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface ISugestaoService
    {
        Task<ReturnSugestaoDto> InsertSugestacao(InsertSugestaoDto dto);
        Task<List<ReturnSugestaoDto>> GetAll();
        Task<List<ReturnSugestaoDto>> GetByMaquinaId(Guid id);
        Task<ReturnSugestaoDto> GetById(int Id);
        Task DeleteAll();

    }
}
