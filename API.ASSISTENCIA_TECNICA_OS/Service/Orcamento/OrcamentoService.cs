using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente;
using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.DTO.Status;
using API.ASSISTENCIA_TECNICA_OS.DTO.Tecnico;
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
        private readonly IStatusOrcamentoService _statusOrcamentoService;
        private readonly ITecnicoNoOrcamentoService _tecnicoNoOrcamentoService;

        public OrcamentoService(Context context,
                                IMapper mapper,
                                IMaquinaClienteService maquinaService,
                                IStatusService statusService,
                                IStatusOrcamentoService statusOrcamentoService,
                                ITecnicoNoOrcamentoService tecnicoNoOrcamentoService)
        {
            _context = context;
            _mapper = mapper;
            _maquinaService = maquinaService;
            _statusService = statusService;
            _statusOrcamentoService = statusOrcamentoService;
            _tecnicoNoOrcamentoService = tecnicoNoOrcamentoService;
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
                listStatus.Add(new StatusOrcamentoModel
                {
                    StatusId = item.Id
                });
            }
            orcamento.Status = StatusSituacaoModel.AGUARDANDO_ATRIBUICAO;
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
        public async Task<List<ReturnOrcamentoDto>> GetByBI()
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
                .ToListAsync();

            var dto = _mapper.Map<List<ReturnOrcamentoDto>>(obj);

            return dto;
        }
        public async Task<ReturnOrcamentoDto> UpdateTecnicoNoOrcamento(UpdateTecnicoNoOrcamentoOuNaManutencaoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.OrcamentoId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.TempoEstimadoOrcamento.ToString()) ||
                string.IsNullOrWhiteSpace(dto.TecnicoId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.UsuarioAlteracaoId.ToString()))
                throw new Exception("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            var verify = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.OrcamentoId);

            if (verify == null)
                throw new Exception("Orçamento não encontrado!") { HResult = 404 };
            var tecnicoNoOrcamento = new InsertTecnicoNoOrcamentoDto
            {
                OrcamentoId = dto.OrcamentoId,
                TecnicoId = dto.TecnicoId
            };

            await _tecnicoNoOrcamentoService.InsertTecnicoNoOrcamento(tecnicoNoOrcamento);

            verify.DataHoraAlteracao = DateTime.UtcNow;
            verify.UsuarioAlteracaoId = dto.UsuarioAlteracaoId;
            verify.TempoEstimadoOrcamento = dto.TempoEstimadoOrcamento;

            verify.Status = StatusSituacaoModel.AGUARDANDO_ORCAMENTO;

            _context.Orcamento.Update(verify);

            await _context.SaveChangesAsync();

            return await GetById(dto.OrcamentoId);

        }

        public async Task<ReturnOrcamentoDto> UpdateStatusForAguardandoLiberacaoOrcamento(UpdateStatusOnBudgetDto dto)
        {
            var transiction = _context.Database.BeginTransaction();

            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.NumeroOrcamento);

            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            obj.Status = StatusSituacaoModel.AGUARDANDO_LIBERACAO_ORCAMENTO;

            _context.Orcamento.Update(obj);
            await _context.SaveChangesAsync();

            var infoApontBudget = new ReturnStatusOnBudgetDto
            {
                OrcamentoId = dto.NumeroOrcamento,
                StatusId = dto.StatusId,
                UsuarioApontamentoId = dto.UsuarioId,
                Observacao = dto.Observacao
            };
            await _statusOrcamentoService.ApontarOrcamentoFinalizado(infoApontBudget);


            transiction.Commit();

            return await GetById(dto.NumeroOrcamento);
        }
        public async Task<ReturnOrcamentoDto> UpdateStatusForOrcamentoRecusado(UpdateStatusOnBudgetDto dto)
        {
            var transiction = _context.Database.BeginTransaction();

            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.NumeroOrcamento);

            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            obj.Status = StatusSituacaoModel.ORCAMENTO_RECUSADO;

            _context.Orcamento.Update(obj);
            await _context.SaveChangesAsync();

            var infoApontBudget = new ReturnStatusOnBudgetDto
            {
                OrcamentoId = dto.NumeroOrcamento,
                StatusId = dto.StatusId,
                UsuarioApontamentoId = dto.UsuarioId,
                Observacao = dto.Observacao
            };
            await _statusOrcamentoService.ApontarNegociacaoFinalizada(infoApontBudget);

            transiction.Commit();

            return await GetById(dto.NumeroOrcamento);
        }
        public async Task<ReturnOrcamentoDto> UpdateStatusForAguardandoSeparacaoPecas(UpdateStatusOnBudgetDto dto)
        {
            var transiction = _context.Database.BeginTransaction();

            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.NumeroOrcamento);

            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            obj.Status = StatusSituacaoModel.AGUARDANDO_PECAS;

            _context.Orcamento.Update(obj);
            await _context.SaveChangesAsync();

            var infoApontBudget = new ReturnStatusOnBudgetDto
            {
                OrcamentoId = dto.NumeroOrcamento,
                StatusId = dto.StatusId,
                UsuarioApontamentoId = dto.UsuarioId,
                Observacao = dto.Observacao
            };
            await _statusOrcamentoService.ApontarNegociacaoFinalizada(infoApontBudget);
            await _statusOrcamentoService.ApontarAguardandoSeparacaoPecas(infoApontBudget);

            transiction.Commit();

            return await GetById(dto.NumeroOrcamento);
        }
        public async Task<ReturnOrcamentoDto> UpdateStatusForSeparacaoPecasFinalizada(UpdateStatusOnBudgetDto dto)
        {
            var transiction = _context.Database.BeginTransaction();

            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.NumeroOrcamento);
            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            obj.Status = StatusSituacaoModel.AGUARDANDO_MANUTENCAO;

            _context.Orcamento.Update(obj);

            await _context.SaveChangesAsync();

            var infoApontBudget = new ReturnStatusOnBudgetDto
            {
                OrcamentoId = dto.NumeroOrcamento,
                StatusId = dto.StatusId,
                UsuarioApontamentoId = dto.UsuarioId,
                Observacao = dto.Observacao
            };
            await _statusOrcamentoService.ApontarSeparacaoPecasFinalizada(infoApontBudget);

            transiction.Commit();

            return await GetById(dto.NumeroOrcamento);
        }
        public async Task<ReturnOrcamentoDto> UpdateStatusForManutencaoIniciada(UpdateStatusOnBudgetDto dto)
        {
            var transiction = _context.Database.BeginTransaction();

            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.NumeroOrcamento);

            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            obj.Status = StatusSituacaoModel.MANUTENCAO_INICIADA;

            _context.Orcamento.Update(obj);
            await _context.SaveChangesAsync();

            var infoApontBudget = new ReturnStatusOnBudgetDto
            {
                OrcamentoId = dto.NumeroOrcamento,
                StatusId = dto.StatusId,
                UsuarioApontamentoId = dto.UsuarioId,
                Observacao = dto.Observacao
            };
            await _statusOrcamentoService.ApontarManutencaoIniciada(infoApontBudget);

            transiction.Commit();

            return await GetById(dto.NumeroOrcamento);
        }
        public async Task<ReturnOrcamentoDto> UpdateStatusForManutencaoFinalizada(UpdateStatusOnBudgetDto dto)
        {
            var transiction = _context.Database.BeginTransaction();

            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.NumeroOrcamento);

            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            obj.Status = StatusSituacaoModel.MANUTENCAO_FINALIZADA;

            _context.Orcamento.Update(obj);
            await _context.SaveChangesAsync();

            var infoApontBudget = new ReturnStatusOnBudgetDto
            {
                OrcamentoId = dto.NumeroOrcamento,
                StatusId = dto.StatusId,
                UsuarioApontamentoId = dto.UsuarioId,
                Observacao = dto.Observacao
            };
            await _statusOrcamentoService.ApontarManutencaoFinalizada(infoApontBudget);

            transiction.Commit();

            return await GetById(dto.NumeroOrcamento);
        }
        public async Task<ReturnOrcamentoDto> UpdateStatusForLimpezaIniciada(UpdateStatusOnBudgetDto dto)
        {
            var transiction = _context.Database.BeginTransaction();

            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.NumeroOrcamento);

            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            obj.Status = StatusSituacaoModel.LIMPEZA;

            _context.Orcamento.Update(obj);
            await _context.SaveChangesAsync();

            transiction.Commit();

            return await GetById(dto.NumeroOrcamento);
        }
        public async Task<ReturnOrcamentoDto> UpdateStatusOrcamentoFinalizado(UpdateStatusOnBudgetDto dto)
        {
            var transiction = _context.Database.BeginTransaction();

            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.NumeroOrcamento);

            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            obj.Status = StatusSituacaoModel.FINALIZADO;

            _context.Orcamento.Update(obj);
            await _context.SaveChangesAsync();

            transiction.Commit();

            return await GetById(dto.NumeroOrcamento);
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

        public async Task<ReturnOrcamentoDto> InsertObservacao(InsertObservacaoDto dto)
        {
            var obj = await _context.Orcamento.SingleOrDefaultAsync(x => x.Id == dto.OrcamentoId);

            obj.Observacao = dto.Observacao;
            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UsuarioId;

            _context.Orcamento.Update(obj);

            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
    }
}
