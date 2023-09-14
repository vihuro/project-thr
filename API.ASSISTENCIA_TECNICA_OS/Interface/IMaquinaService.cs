using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.DTO.OrdemServico;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IMaquinaService
    {
        Task<ReturnMaquinaComPecasDto> Insert(InsertMaquinaDto dto);
        Task<List<ReturnMaquinaComPecasDto>> GetAll();
        Task<List<ReturnMaquinaComPecasDto>> GetBySemAtribuicao();
        Task<ReturnMaquinaComPecasDto> GetById(Guid id);
        Task<ReturnMaquinaComPecasDto> GetByNumeroSerie(string numeroSerie);
        Task<bool> DeleteAll();
        Task<bool> DeleteById(Guid id); 
    }
}
