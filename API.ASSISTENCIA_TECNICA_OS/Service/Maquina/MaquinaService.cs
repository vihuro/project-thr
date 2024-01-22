using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Maquina
{
    public class MaquinaService : IMaquinaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IMaquinaClienteService _maquinaClienteSerice;
        private readonly IPecasRadarService _maquinaRadarService;

        public MaquinaService(Context context,
                                IMapper mapper,
                                IMaquinaClienteService maquinaClienteSerice,
                                IPecasRadarService maquinaRadarService)
        {
            _context = context;
            _mapper = mapper;
            _maquinaClienteSerice = maquinaClienteSerice;
            _maquinaRadarService = maquinaRadarService;
        }

        public async Task<bool> DeleteAll()
        {
            var list = await _context
                .Maquina.ToListAsync();
            _context.Maquina.RemoveRange(list);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var obj = await _context
                .Maquina.SingleOrDefaultAsync(x => x.Id == id);
            _context.Maquina.Remove(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ReturnMaquinaComPecasDto>> GetAll()
        {
            var list = await _context.Maquina
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(p => p.Pecas)
                    .ThenInclude(p => p.Peca)
                .AsNoTracking()
                .OrderBy(x => x.CodigoMaquina)
                .ToListAsync();

            var dto = _mapper.Map<List<ReturnMaquinaComPecasDto>>(list);

            return dto;
        }
        public async Task<List<ReturnMaquinaComPecasDto>> GetBySemAtribuicao()
        {
            var list = await _context.Maquina
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .AsNoTracking()
                .Where(x => !x.Atribuida)
                .ToListAsync();

            var dto = _mapper.Map<List<ReturnMaquinaComPecasDto>>(list);

            return dto;
        }
        public async Task<ReturnMaquinaComPecasDto> AtribuirMaquina(AtribuicaoMaquinaDto dto)
        {
            var obj = await _context.Maquina.FirstOrDefaultAsync(x => x.Id == dto.MaquinaId) ??
                throw new CustomException("Máquina não encontrada!") { HResult = 404 };

            var exists = await _maquinaClienteSerice.MaquinaAtribuida(dto.MaquinaId);
            if (exists)
                throw new CustomException("Máquina já atribuída!");

            obj.Atribuida = true;
            obj.UsuarioAlteracaoId = dto.UserId;
            obj.DataHoraAlteracao = DateTime.UtcNow;

            _context.Maquina.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
        public async Task<ReturnMaquinaComPecasDto> DesatribuirMaquina(AtribuicaoMaquinaDto dto)
        {

            var obj = await _context.Maquina.FirstOrDefaultAsync(x => x.Id == dto.MaquinaId) ??
                throw new CustomException("Máquina não encontrada!") { HResult = 404 };

            var teste = await _maquinaClienteSerice.DeleteMaquinaInCliente(dto.MaquinaId);


            obj.Atribuida = false;
            obj.UsuarioAlteracaoId = dto.UserId;
            obj.DataHoraAlteracao = DateTime.UtcNow;

            _context.Maquina.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }

        public async Task<ReturnMaquinaComPecasDto> GetById(Guid id)
        {
            var obj = await _context.Maquina
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(p => p.Pecas)
                    .ThenInclude(p => p.Peca)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id) ??
                throw new CustomException("Máquina não encontrada!") { HResult = 404 };

            var dto = _mapper.Map<ReturnMaquinaComPecasDto>(obj);

            return dto;
        }

        public async Task<ReturnMaquinaComPecasDto> GetByNumeroSerie(string numeroSerie)
        {
            var obj = await _context.Maquina
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .Include(p => p.Pecas)
                    .ThenInclude(p => p.Peca)
                .OrderBy(x => x.CodigoMaquina)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.NumeroSerie == numeroSerie) ??
                throw new CustomException("Máquina não encontrada!") { HResult = 404 };

            var dto = _mapper.Map<ReturnMaquinaComPecasDto>(obj);

            return dto;
        }
        public async Task<ReturnMaquinaComPecasDto> GetByCodigo(string codigo)
        {
            var listRadar = await _maquinaRadarService.GetMaquinaEAperelhos();

            var maquina = listRadar.Where(c => c.Codigo.ToUpper() == codigo.ToUpper()).FirstOrDefault();

            if (maquina == null) throw new CustomException("Máquina não encontrada!") { HResult = 404 };

            var dto = new ReturnMaquinaComPecasDto
            {
                CodigoMaquina = maquina.Codigo,
                DescricaoMaquina = maquina.Descricao,
                Unidade = maquina.Unidade
            };

            return dto;

        }

        public async Task<ReturnMaquinaComPecasDto> Insert(InsertMaquinaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CodigoMaquina) ||
                string.IsNullOrWhiteSpace(dto.DescricaoMaquina) ||
                string.IsNullOrWhiteSpace(dto.NumeroSerie) ||
                string.IsNullOrWhiteSpace(dto.UserId.ToString()))
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            var verify = await _context.Maquina
                .AsNoTracking()
                .AnyAsync(x => x.NumeroSerie.ToUpper() == dto.NumeroSerie.ToUpper());
            if (verify)
                throw new CustomException("Número de série já cadastrado!") { HResult = 400 };

            var listMachineInReportRadar = await _maquinaRadarService.GetMaquinaEAperelhos();
            var verifyExistinMachineForCode = listMachineInReportRadar.Any(c => c.Codigo.ToUpper() == dto.CodigoMaquina.ToUpper());

            if (!verifyExistinMachineForCode)
                throw new CustomException("Código não encontrado!") { HResult = 404 };

            var obj = _mapper.Map<MaquinaModel>(dto);
            _context.Maquina.Add(obj);

            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
        public async Task<ReturnMaquinaComPecasDto> UpdateMaquina(UpdateMaquinaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CodigoMaquina) ||
                string.IsNullOrWhiteSpace(dto.DescricaoMaquina) ||
                string.IsNullOrWhiteSpace(dto.NumeroSerie) ||
                string.IsNullOrWhiteSpace(dto.UserId.ToString()))
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            var verify = await _context.Maquina
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.NumeroSerie.ToUpper() == dto.NumeroSerie.ToUpper() && x.Id != dto.MaquinaId);
            if (verify != null)
                throw new CustomException("Número de série já cadastrado!") { HResult = 400 };
            var obj = await _context.Maquina
                .Include(p => p.Pecas)
                    .ThenInclude(p => p.Peca)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.MaquinaId);

            if (obj == null)
                throw new CustomException("MÁQUINA NÃO ENCONTRADA!") { HResult = 404 };


            obj.CodigoMaquina = dto.CodigoMaquina;
            obj.DescricaoMaquina = dto.DescricaoMaquina;
            obj.Ativo = dto.Ativo;
            obj.UsuarioAlteracaoId = dto.UserId;
            obj.DataHoraAlteracao = DateTime.UtcNow;

            var listMaquina = new List<PecasPorMaquinaModel>();

            foreach (var maquina in dto.Pecas)
            {
                listMaquina.Add(new PecasPorMaquinaModel
                {
                    PecaId = maquina.IdPeca
                });
            }
            obj.Pecas = listMaquina;

            _context.Maquina.Update(obj);

            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
    }
}
