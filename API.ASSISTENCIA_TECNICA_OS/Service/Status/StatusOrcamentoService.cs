using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Status
{
    public class StatusOrcamentoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public StatusOrcamentoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<object> ApontarAguardandoOrcamento()
        {
            return new object();
        }
        public async Task<object> ApontarOrcamentoFinalizado()
        {
            return new object();
        }
    }
}
