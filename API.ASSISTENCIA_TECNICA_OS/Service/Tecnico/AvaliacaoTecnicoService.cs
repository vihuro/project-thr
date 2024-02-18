using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using AutoMapper;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Tecnico
{
    public class AvaliacaoTecnicoService : IAvaliacaoTecnicoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public AvaliacaoTecnicoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
