using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.MaquinaCliente;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.MaquinaCliente
{
    public class MaquinaClienteService : IMaquinaClienteService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MaquinaClienteService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteMaquinaInCliente(Guid id)
        {
            var obj = await _context.MaquinaCliente.FirstOrDefaultAsync(x => x.MaquinaId == id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<ReturnMaquinaClienteDto> GetByMaquinaIndCliente(Guid id)
        {
            var obj = await _context.MaquinaCliente
                .Include(m => m.Maquina)
                    .ThenInclude(p => p.Pecas)
                        .ThenInclude(p => p.Peca)
                .Include(c => c.Cliente)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.MaquinaId == id);

            if (obj == null) throw new CustomException("Màquina não encontrada!") { HResult = 404 };

            var dto = _mapper.Map<ReturnMaquinaClienteDto>(obj);

            return dto;
        }

        public async Task<bool> MaquinaAtribuida(Guid maquinaId)
        {
            var obj = await _context.MaquinaCliente.Where(x => x.MaquinaId == maquinaId).ToListAsync();

            if (obj.Count > 1) return true;

            return false;
        }

        public async Task<ReturnMaquinaClienteDto> UpdateMaquinaInCliente(InsertMaquinaInClientDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MaquinaId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.ClienteId.ToString()))
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var validaDataRetorno = DateTime.Now < dto.DataSugeridaRetorno;

            if (dto.TipoAquisicao == ETipoAquisicaoDto.EMPRESTIMO &&
                string.IsNullOrEmpty(dto.DataSugeridaRetorno.ToString()) ||
                validaDataRetorno)
                throw new Exception("Não é possível lançar uma máquina como empréstimo sem colocar uma data sugerida para retorno!");


            var verify = await _context.MaquinaCliente.AnyAsync(x => x.MaquinaId == dto.MaquinaId);
            if (verify)
                throw new CustomException("Essa máquina já está em uso!");

            var obj = _mapper.Map<MaquinaClienteModel>(dto);

            _context.MaquinaCliente.Add(obj);
            await _context.SaveChangesAsync();

            obj = await _context.MaquinaCliente
                .Include(x => x.Maquina)
                .Include(x => x.Cliente)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            return _mapper.Map<ReturnMaquinaClienteDto>(obj);

        }
        private async Task<MaquinaClienteModel> ChangeStatusInMachine(UpdateStatusMaquina dto)
        {
            var obj = await _context.MaquinaCliente
                                    .Include(m => m.Maquina)
                                    .Include(c => c.Cliente)
                                    .SingleOrDefaultAsync(x => x.MaquinaId == dto.MaquinaId) ??
                            throw new CustomException("Máquina não encontrada!") { HResult = 404 };

            return obj;
        }
        public async Task<ReturnMaquinaClienteDto> UpdateStatusForLiberada(UpdateStatusMaquina dto)
        {
            var obj = await ChangeStatusInMachine(dto);

            obj.Status = StatusMaquinaClienteModel.LIBERADA;
            _context.MaquinaCliente.Update(obj);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReturnMaquinaClienteDto>(obj);
        }
        public async Task<ReturnMaquinaClienteDto> UpdateStatusForAguardandoOrcamento(UpdateStatusMaquina dto)
        {
            var obj = await ChangeStatusInMachine(dto);

            obj.Status = StatusMaquinaClienteModel.AGUARDANDO_ORCAMENTO;
            _context.MaquinaCliente.Update(obj);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReturnMaquinaClienteDto>(obj);
        }
        public async Task<ReturnMaquinaClienteDto> UpdateStatusForAguardandoAprovacao(UpdateStatusMaquina dto)
        {
            var obj = await ChangeStatusInMachine(dto);

            obj.Status = StatusMaquinaClienteModel.AGUARDANDO_APROVACAO;
            _context.MaquinaCliente.Update(obj);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReturnMaquinaClienteDto>(obj);
        }
        public async Task<ReturnMaquinaClienteDto> UpdateStatusForEmManutencao(UpdateStatusMaquina dto)
        {
            var obj = await ChangeStatusInMachine(dto);

            obj.Status = StatusMaquinaClienteModel.EM_MANUTENCAO;
            _context.MaquinaCliente.Update(obj);
            await _context.SaveChangesAsync();

            return _mapper.Map<ReturnMaquinaClienteDto>(obj);
        }
    }
}
