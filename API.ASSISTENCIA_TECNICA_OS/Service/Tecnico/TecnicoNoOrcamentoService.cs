using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Tecnico
{
    public class TecnicoNoOrcamentoService : ITecnicoNoOrcamentoService
    {
        private readonly Context _context;

        public TecnicoNoOrcamentoService(Context context)
        {
            _context = context;
        }

        public async Task InsertTecnicoNoOrcamento(InsertTecnicoNoOrcamentoDto dto)
        {
            var verify = await _context.TecnicoOrcamento
                                .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId) ;
            if (verify == null)
            {
                verify = new TecnicoOrcamentoModel()
                {
                    OrcamentoId = dto.OrcamentoId
                };
            }
            verify.TecnicoId = dto.TecnicoId;
            _context.TecnicoOrcamento.Update(verify);

        }
    }
}
