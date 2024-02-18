using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Tecnico
{
    public class TecnicoNaManutencaoService : ITecnicoNaManutencaoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TecnicoNaManutencaoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task InsertTecnicoNaManutencao(InsertTecnicoNoOrcamentoDto dto)
        {
            var verify = await _context.TecnicoManutencao
                                        .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId);
            if(verify == null)
            {
                verify = new TecnicoManutencaoModel()
                {
                    OrcamentoId = dto.OrcamentoId
                };
            }
            verify.TecnicoId = dto.TecnicoId;

            _context.TecnicoManutencao.Update(verify);

        }
    }
}
