using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Status;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Status
{
    public class StatusOrcamentoService : IStatusOrcamentoService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public StatusOrcamentoService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task ApontarAguardandoOrcamento(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId);

            var objApontamento = new UsuarioApontamentoInicioStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoInicioId = dto.UsuarioApontamentoId,
            };
            obj.DataHoraInicio = DateTime.UtcNow;
            obj.Observacao = dto.Observacao != "" ? $"{dto.Observacao} - Apontado no Início! \n" : "";
            _context.StatusOrcamento.Update(obj);
            _context.UsuarioApontamentoInicioStatus.Add(objApontamento);

            await _context.SaveChangesAsync();

        }
        public async Task ApontarOrcamentoFinalizado(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId);

            var objApontamento = new UsuarioApontamentoFimStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoFimId = dto.UsuarioApontamentoId
            };

            obj.DataHoraFim = DateTime.UtcNow;
            obj.Observacao = dto.Observacao != "" ? $"{obj.Observacao + dto.Observacao} - Apontado no Fim! \n" : obj.Observacao;
            _context.StatusOrcamento.Update(obj);
            _context.UsuarioApotamentoFimStatus.Add(objApontamento);
            await _context.SaveChangesAsync();

            await ApontarNegociacaoIniciada(dto);
        }
        private async Task ApontarNegociacaoIniciada(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                     .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId + 1);

            var objApontamento = new UsuarioApontamentoInicioStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoInicioId = dto.UsuarioApontamentoId
            };

            obj.DataHoraInicio = DateTime.UtcNow;
            obj.Observacao = dto.Observacao != "" ? $"{dto.Observacao} - Apontado no Início! \n" : "";
            _context.StatusOrcamento.Update(obj);
            _context.UsuarioApontamentoInicioStatus.Add(objApontamento);
            await _context.SaveChangesAsync();
        }
        public async Task ApontarNegociacaoFinalizada(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                        .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId);

            var objApontamento = new UsuarioApontamentoFimStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoFimId = dto.UsuarioApontamentoId
            };

            obj.DataHoraFim = DateTime.UtcNow;
            obj.Observacao = dto.Observacao != "" ? $"{obj.Observacao + dto.Observacao} - Apontado no Fim! \n" : obj.Observacao;
            _context.StatusOrcamento.Update(obj);
            _context.UsuarioApotamentoFimStatus.Add(objApontamento);
            await _context.SaveChangesAsync();
        }
        public async Task ApontarAguardandoSeparacaoPecas(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
            .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId + 1);

            var objApontamento = new UsuarioApontamentoInicioStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoInicioId = dto.UsuarioApontamentoId
            };

            obj.DataHoraInicio = DateTime.UtcNow;
            obj.Observacao = dto.Observacao != "" ? $"{dto.Observacao} - Apontado no Início! \n" : "";
            _context.StatusOrcamento.Update(obj);
            _context.UsuarioApontamentoInicioStatus.Add(objApontamento);
            await _context.SaveChangesAsync();
        }
        public async Task ApontarSeparacaoPecasFinalizada(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId);
            var objApontamento = new UsuarioApontamentoFimStatusModel
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoFimId = dto.UsuarioApontamentoId
            };
            obj.DataHoraFim = DateTime.UtcNow;
            obj.Observacao = dto.Observacao != "" ? $"{obj.Observacao + dto.Observacao} - Apontado no Fim! \n" : obj.Observacao;

            _context.StatusOrcamento.Update(obj);
            _context.UsuarioApotamentoFimStatus.Add(objApontamento);
            await _context.SaveChangesAsync();
        }


        /*public async Task ApontarOrcamentoAprovado(ReturnStatusOnBudgetDto dto)
        {
            await ApontarNegociacaoFinalizada(dto);
            var obj = await _context.StatusOrcamento
                            .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId + 1);
            var objApontamentoInicio = new UsuarioApontamentoInicioStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoInicioId = dto.UsuarioApontamentoId
            };
            var objApontamentoFim = new UsuarioApontamentoFimStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoFimId = dto.UsuarioApontamentoId
            };

            obj.DataHoraInicio = DateTime.UtcNow;
            obj.DataHoraFim = DateTime.UtcNow;
            obj.Observacao = $"{dto.Observacao}";

            _context.UsuarioApontamentoInicioStatus.Add(objApontamentoInicio);
            _context.UsuarioApotamentoFimStatus.Add(objApontamentoFim);
            _context.StatusOrcamento.Update(obj);
            await _context.SaveChangesAsync();
        }*/

        /*public async Task ApontarOrcamentoReprovado(ReturnStatusOnBudgetDto dto)
        {
            await ApontarNegociacaoFinalizada(dto);
            var obj = await _context.StatusOrcamento
                            .SingleOrDefaultAsync(x => 
                            x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId + 2);

            var objApontamentoInicio = new UsuarioApontamentoInicioStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoInicioId = dto.UsuarioApontamentoId
            };
            var objApontamentoFim = new UsuarioApontamentoFimStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoFimId = dto.UsuarioApontamentoId
            };

            obj.DataHoraInicio = DateTime.UtcNow;
            obj.DataHoraFim = DateTime.UtcNow;
            obj.Observacao = $"{dto.Observacao}";

            _context.UsuarioApontamentoInicioStatus.Add(objApontamentoInicio);
            _context.UsuarioApotamentoFimStatus.Add(objApontamentoFim);
            _context.StatusOrcamento.Update(obj);
            await _context.SaveChangesAsync();

        }*/
        public async Task ApontarManutencaoIniciada(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                            .SingleOrDefaultAsync(x =>
                            x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId);
            var objApontamentoInicio = new UsuarioApontamentoInicioStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoInicioId = dto.UsuarioApontamentoId
            };


            obj.DataHoraInicio = DateTime.UtcNow;
            obj.Observacao = dto.Observacao != "" ? $"{dto.Observacao} - Apontado Início! \n" : "";

            _context.StatusOrcamento.Update(obj);
            _context.UsuarioApontamentoInicioStatus.Add(objApontamentoInicio);

            await _context.SaveChangesAsync();
        }
        public async Task ApontarManutencaoFinalizada(ReturnStatusOnBudgetDto dto)
        {
            var obj = await _context.StatusOrcamento
                            .SingleOrDefaultAsync(x => x.OrcamentoId == dto.OrcamentoId && x.StatusId == dto.StatusId);

            var objApontamentoFim = new UsuarioApontamentoFimStatusModel()
            {
                StatusOrcamentoId = obj.Id,
                UsuarioApontamentoFimId = dto.UsuarioApontamentoId
            };
            obj.DataHoraFim = DateTime.UtcNow;
            obj.Observacao = dto.Observacao != "" ? $"{obj.Observacao + dto.Observacao} - Apontado no Fim! \n" : obj.Observacao;

            _context.StatusOrcamento.Update(obj);
            _context.UsuarioApotamentoFimStatus.Add(objApontamentoFim);
            await _context.SaveChangesAsync();
        }
    }
}
