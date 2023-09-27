using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using System.Threading.Tasks;

namespace API.ASSISTENCIA_TECNICA_OS.Interface
{
    public interface IOrcamentoService
    {
        Task<ReturnOrcamentoDto> InsertOrcamento(InsertOrcamentoDto dto);
        Task<ReturnOrcamentoDto> GetById(int numeroOrcamento);
        Task<List<ReturnOrcamentoResumidoDto>> GetAll();
    }
}
