using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente;
using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Interface;
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

            var transiction = _context.Database.BeginTransaction();

            var orcamento = _mapper.Map<OrcamentoModel>(dto);

            orcamento.MaquinaClienteId = maquinaInCliente.Id;


            var listStausService = await _statusService.GetAll();
            var listStatus = new List<StatusOrcamentoModel>();

            foreach (var item in listStausService)
            {
                var newItem = new StatusOrcamentoModel();
                /*if (item.Status == "AGUARDANDO ORÇAMENTO")
                {
                    newItem.DataHoraInicio = DateTime.UtcNow;
                    newItem.UsuarioApontamentoInicio = new UsuarioApontamentoInicioStatusModel
                    {
                        UsuarioApontamentoInicioId = dto.UserId,
                    };

                }*/
                newItem.StatusId = item.Id;
                listStatus.Add(newItem);

            }
            orcamento.Status = StatusSituacaoModel.AGUARDANDO_ORCAMENTO;
            orcamento.StatusOrcamento = listStatus;

            _context.Orcamento.Add(orcamento);
            await _context.SaveChangesAsync();

            var status = new UpdateStatusMaquina
            {
                MaquinaId = maquinaInCliente.Maquina.MaquinaId,
            };

            await _maquinaService.UpdateStatusForAguardandoOrcamento(status);

            transiction.Commit();

            return await GetById(orcamento.Id);

        }
        public async Task<ReturnOrcamentoDto> GetById(int numeroOrcamento)
        {
            var obj = await _context.Orcamento
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(m => m.MaquinaCliente)
                    .ThenInclude(m => m.Maquina)
                .Include(c => c.MaquinaCliente)
                    .ThenInclude(c => c.Cliente)
                .Include(t => t.TecnicoManutenco)
                    .ThenInclude(u => u.Tecnico)
                        .ThenInclude(u => u.Usuario)
                .Include(t => t.TecnicoOrcamento)
                    .ThenInclude(u => u.Tecnico)
                        .ThenInclude(u => u.Usuario)
                .Include(p => p.Pecas)
                    .ThenInclude(p => p.Peca)
                .Include(s => s.StatusOrcamento.OrderBy(x => x.StatusId))
                    .ThenInclude(s => s.Status)
                 .Include(s => s.StatusOrcamento)
                    .ThenInclude(u => u.UsuarioApontamentoInicio)
                        .ThenInclude(u => u.UsuarioApontamentoInicio)
                 .Include(s => s.StatusOrcamento)
                    .ThenInclude(u => u.UsuarioApontamentFim)
                        .ThenInclude(u => u.UsuarioApontamentoFim)
                .Include(d => d.Diario)
                    .ThenInclude(u => u.UsuarioApontamento)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == numeroOrcamento);

            var dto = _mapper.Map<ReturnOrcamentoDto>(obj);

            return dto;
        }
        public async Task<List<ReturnOrcamentoResumidoDto>> GetAll()
        {
            var list = await _context.Orcamento
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(m => m.MaquinaCliente)
                    .ThenInclude(m => m.Maquina)
                .Include(c => c.MaquinaCliente)
                    .ThenInclude(c => c.Cliente)
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .ToListAsync();

            var dto = _mapper.Map<List<ReturnOrcamentoResumidoDto>>(list);

            return dto;
        }
    }
}
