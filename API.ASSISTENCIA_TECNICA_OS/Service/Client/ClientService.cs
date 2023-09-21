using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Client;
using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Client;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.auth.Service.ExceptionService;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Client
{
    public class ClientService : IClientInteService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly ICEPService _cepSerive;
        private readonly IMaquinaService _maquinaService;

        public ClientService(Context context,
                                IMapper mapper,
                                ICEPService cepSerive,
                                IMaquinaService maquinaService)
        {
            _context = context;
            _mapper = mapper;
            _cepSerive = cepSerive;
            _maquinaService = maquinaService;
        }

        public async Task<ReturnClientDto> Insert(InsertClientDto dto)
        {

            await ValidacaoInsert(dto);

            using var transaction = _context.Database.BeginTransaction();

            var obj = _mapper.Map<ClientModel>(dto);

            _context.Cliente.Add(obj);

            await _context.SaveChangesAsync();
            for (var i = 0; i < obj.Maquinas.Count; i++)
            {
                var atribuicao = new AtribuicaoMaquinaDto
                {
                    MaquinaId = obj.Maquinas[i].MaquinaId,
                    UserId = obj.UsuarioAlteracaoId
                };
                await _maquinaService.AtribuirMaquina(atribuicao);
            }
            transaction.Commit();


            return await GetById(obj.Id);

        }
        public async Task<ReturnClientDto> UpdateCliente(UpdateClienteDto dto)
        {
            await ValidacaoUpdate(dto);

            using var transaction = _context.Database.BeginTransaction();

            var obj = await _context.Cliente
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(m => m.Maquinas)
                    .ThenInclude(m => m.Maquina)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == dto.IdCliente);

            obj.Cnpj = dto.Cnpj;
            obj.CEP = dto.Cep;
            obj.Estado = dto.Estado;
            obj.Cidade = dto.Cidade;
            obj.CodigoRadar = dto.CodigoRadar.ToUpper();
            obj.Complemento = dto.Complemento.ToUpper();
            obj.ContatoTelefone = dto.ContatoTelefone;
            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.UsuarioAlteracaoId = dto.UserId;
            obj.NomeContatoClient = dto.NomeContatoCliente;
            obj.Nome = dto.Nome.ToUpper();
            obj.NumeroEstabelecimento = dto.NumeroEstabelecimento;
            obj.Regiao = dto.Regiao;
            obj.Rua = dto.Rua;

            var atribuicao = new AtribuicaoMaquinaDto()
            {
                UserId = dto.UserId,
            };
            var maquina = new List<MaquinaClienteModel>();

            var maquinaParaAtribuir = dto.MaquinaCliente.Select(m => m.MaquinaId).ToList();
            var maquinaParaDesatribuir = obj.Maquinas.Select(m => m.MaquinaId).Except(maquinaParaAtribuir).ToList();

            foreach (var maquinaIdParaDesatribuir in maquinaParaDesatribuir)
            {
                atribuicao.MaquinaId = maquinaIdParaDesatribuir;
                await _maquinaService.DesatribuirMaquina(atribuicao);
                obj.Maquinas.RemoveAll(m => m.MaquinaId == maquinaIdParaDesatribuir);

            }
            foreach (var maquinaIdParaAtribuir in maquinaParaAtribuir)
            {
                if (!obj.Maquinas.Any(m => m.MaquinaId == maquinaIdParaAtribuir))
                {
                    atribuicao.MaquinaId = maquinaIdParaAtribuir;
                    await _maquinaService.AtribuirMaquina(atribuicao);

                    obj.Maquinas.Add(new MaquinaClienteModel
                    {
                        MaquinaId = maquinaIdParaAtribuir
                    });
                }
            }

            _context.Cliente.Update(obj);
            await _context.SaveChangesAsync();

            transaction.Commit();

            return await GetById(obj.Id);
        }
        private async Task ValidacaoUpdate(UpdateClienteDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.IdCliente.ToString()) ||
                string.IsNullOrWhiteSpace(dto.Cep) ||
                string.IsNullOrWhiteSpace(dto.Nome) ||
                string.IsNullOrWhiteSpace(dto.Cnpj) ||
                string.IsNullOrWhiteSpace(dto.CodigoRadar) ||
                string.IsNullOrWhiteSpace(dto.Cidade) ||
                string.IsNullOrWhiteSpace(dto.Rua) ||
                string.IsNullOrWhiteSpace(dto.NumeroEstabelecimento) ||
                string.IsNullOrWhiteSpace(dto.Regiao) ||
                string.IsNullOrEmpty(dto.Cep))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            if (dto.Cnpj.Length != 14)
                throw new CustomException("O CNPJ Precisa conter 14 números!") { HResult = 400 };


            //Para validar se o cep está correto
            await _cepSerive.Get(Convert.ToInt32(dto.Cep));


            //Verifica se código desse cliente já está sendo usado
            var verifyCodigoRadar = await _context.Cliente.SingleOrDefaultAsync(x => x.CodigoRadar == dto.CodigoRadar && x.Id != dto.IdCliente);
            if (verifyCodigoRadar != null)
                throw new CustomException("Já existe um cliente com esse código do radar!");
            var verifyCnpj = await _context.Cliente.SingleOrDefaultAsync(x => x.Cnpj == dto.Cnpj && x.Id != dto.IdCliente);
            if (verifyCnpj != null)
                throw new CustomException("CNPJ já cadastrado!");
        }
        private async Task ValidacaoInsert(InsertClientDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Cep) ||
                string.IsNullOrWhiteSpace(dto.Nome) ||
                string.IsNullOrWhiteSpace(dto.Cnpj) ||
                string.IsNullOrWhiteSpace(dto.CodigoRadar) ||
                string.IsNullOrWhiteSpace(dto.Cidade) ||
                string.IsNullOrWhiteSpace(dto.Rua) ||
                string.IsNullOrWhiteSpace(dto.NumeroEstabelecimento) ||
                string.IsNullOrWhiteSpace(dto.Regiao) ||
                string.IsNullOrEmpty(dto.Cep))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            if (dto.Cnpj.Length != 14)
                throw new CustomException("O CNPJ Precisa conter 14 números!") { HResult = 400 };


            //Para validar se o cep está correto
            await _cepSerive.Get(Convert.ToInt32(dto.Cep));


            //Verifica se código desse cliente já está sendo usado
            var verifyCodigoRadar = await _context.Cliente.SingleOrDefaultAsync(x => x.CodigoRadar == dto.CodigoRadar);
            if (verifyCodigoRadar != null)
                throw new CustomException("Já existe um cliente com esse código do radar!");
            var verifyCnpj = await _context.Cliente.SingleOrDefaultAsync(x => x.Cnpj == dto.Cnpj);
            if (verifyCnpj != null)
                throw new CustomException("CNPJ já cadastrado!");
        }

        public async Task<List<ReturnClientDto>> GetAll()
        {
            var obj = await _context.Cliente
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(m => m.Maquinas)
                    .ThenInclude(m => m.Maquina)
                .AsNoTracking()
                .OrderBy(m => m.Nome)
                .ToListAsync();
            var dto = _mapper.Map<List<ReturnClientDto>>(obj);

            return dto;
        }
        public async Task<ReturnClientDto> GetById(Guid id)
        {
            var obj = await _context.Cliente
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id) ??
                throw new CustomException("Cliente não encontrado!");
            var dto = _mapper.Map<ReturnClientDto>(obj);
            return dto;
        }
        public async Task<ReturnClientDto> GetByCodigoRadar(string codigoRadar)
        {
            var obj = await _context.Cliente
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.CodigoRadar == codigoRadar) ??
                throw new CustomException("Cliente não encontrado!");
            var dto = _mapper.Map<ReturnClientDto>(obj);
            return dto;
        }
        public async Task<bool> DeleteAll()
        {
            var list = await _context.Cliente
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .AsNoTracking()
                .ToListAsync();
            _context.Cliente.RemoveRange(list);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
