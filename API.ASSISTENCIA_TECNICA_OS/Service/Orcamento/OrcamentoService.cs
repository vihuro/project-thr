using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Orcamento
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IMaquinaClienteService _maquinaService;
        private readonly IStatusService _statusService;

        public OrcamentoService(Context context,
                                IMapper mapper,
                                IMaquinaClienteService maquinaService,
                                IStatusService statusService)
        {
            _context = context;
            _mapper = mapper;
            _maquinaService = maquinaService;
            _statusService = statusService;
        }

        public async Task<ReturnOrcamentoDto> InsertOrcamento(InsertOrcamentoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MaquinaId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.DescricaoServico) ||
                string.IsNullOrWhiteSpace(dto.UserId.ToString()))
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var maquinaInCliente = await _maquinaService.GetByMaquinaIndCliente(dto.MaquinaId);

            var orcamento = _mapper.Map<OrcamentoModel>(dto);

            orcamento.MaquinaClienteId = maquinaInCliente.Id;

            var listPecas = new List<PecasMaquinaOrcamentoModel>();

            foreach (var item in maquinaInCliente.Maquina.Pecas)
            {
                listPecas.Add(new PecasMaquinaOrcamentoModel
                {
                    Conserto = false,
                    Troca = false,
                    MaquinaId = dto.MaquinaId,
                    PecaId = item.PecaId,

                });
            
            }
            var listStausService = await _statusService.GetAll();
            var listStatus = new List<StatusOrcamentoModel>();
            foreach(var item in listStausService)
            {
                listStatus.Add(new StatusOrcamentoModel
                {
                    StatusId = item.Id
                });
            }
            orcamento.Status = listStatus;
            orcamento.Pecas = listPecas;

            _context.Orcamento.Add(orcamento);
            await _context.SaveChangesAsync();

            return null;

        }
        public async Task<List<ReturnOrcamentoDto>> GetAll()
        {
            var list = await _context.Orcamento
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(m => m.MaquinaCliente)
                    .ThenInclude(m => m.Maquina)
                .Include(c => c.MaquinaCliente)
                    .ThenInclude(c => c.Cliente)
                .Include(p => p.Pecas)
                    .ThenInclude(p => p.Peca)
                .Include(s => s.Status)
                    .ThenInclude(s => s.Status)
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<ReturnOrcamentoDto>>(list);

            return dto;
        }
    }
}
