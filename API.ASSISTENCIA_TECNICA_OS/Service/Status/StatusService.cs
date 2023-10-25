using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Status;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Status
{
    public class StatusService : IStatusService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public StatusService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnStatusDto> Insert(InsertStatusDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Status))
                throw new CustomException("Campo obrigatório vazio!");

            var verify = _context.Status
                .Any(c => c.Status == dto.Status.ToUpper());
            if (verify)
                throw new CustomException("Esse status já foi cadastradro!");


            var obj = _mapper.Map<StatusModel>(dto);

            _context.Status.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);


        }
        public async Task<List<ReturnStatusDto>> InsertStatusList(Guid userId)
        {
            var list = new List<string>()
            {
                "ORÇAMENTO PENDENTE",
                "AGUARDANDO ORÇAMENTO",
                "EM NEGOCIAÇÃO",
                "ORÇAMENTO APROVADO",
                "ORÇAMENTO RECUSADO",
                "AGUARDANDO MANUTENÇÃO",
                "MANUTENÇÃO INICIADA",
                "MANUNTENÇÃO FINALIZADA"
            };
            var verifyExistisStatusInDataBase = _context.Status.Any(x => list.Contains(x.Status));
            if (verifyExistisStatusInDataBase)
                throw new CustomException("Esse status já foi cadastradro!");
            var obj = _mapper.Map<List<StatusModel>>(list);
            _context.Status.AddRange(obj);
            await _context.SaveChangesAsync();

            var returObjMapper = _mapper.Map<List<ReturnStatusDto>>(obj);
            return returObjMapper;
        }

        public async Task<ReturnStatusDto> GetById(int id)
        {
            var obj = await _context.Status
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ReturnStatusDto>(obj);
        }
        public async Task<List<ReturnStatusDto>> GetAll()
        {
            var list = await _context.Status
                .ToListAsync();

            return _mapper.Map<List<ReturnStatusDto>>(list);
        }
    }
}
