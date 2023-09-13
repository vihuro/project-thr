using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Client;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Client;
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

        public ClientService(Context context,
                            IMapper mapper,
                            ICEPService cepSerive)
        {
            _context = context;
            _mapper = mapper;
            _cepSerive = cepSerive;
        }

        public async Task<ReturnClientDto> Insert(InsertClientDto dto)
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


            //Para vaidar se o cep está correto
            await _cepSerive.Get(Convert.ToInt32(dto.Cep));


            //Verifica se código desse cliente já está sendo usado
            var verifyCodigoRadar = await _context.Cliente.SingleOrDefaultAsync(x => x.CodigoRadar == dto.CodigoRadar);
            if (verifyCodigoRadar != null)
                throw new CustomException("Já existe um cliente com esse código do radar!");
            var verifyCnpj = await _context.Cliente.SingleOrDefaultAsync(x => x.Cnpj == dto.Cnpj);
            if (verifyCnpj != null)
                throw new CustomException("CNPJ já cadastrado!");

            var obj = _mapper.Map<ClientModel>(dto);
            try
            {
                _context.Cliente.Add(obj);

                await _context.SaveChangesAsync();


                return await GetById(obj.Id);
            }
            catch (Exception ex)
            {

                throw new CustomException(ex.Message);
            }



        }
        public async Task<List<ReturnClientDto>> GetAll()
        {
            var obj = await _context.Cliente
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .Include(m => m.Maquinas)
                    .ThenInclude(m => m.Maquina)
                .AsNoTracking()
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
