using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento.Sugestao;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Orcamento;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Orcamento
{
    public class SugestacaoService : ISugestaoService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;

        public SugestacaoService(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task DeleteAll()
        {
            var objList = await _context.Sugestao.ToListAsync();
            _context.RemoveRange(objList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ReturnSugestaoDto>> GetAll()
        {
            var entityList = await _context.Sugestao
                                    .Include(m => m.Maquina)
                                    .Include(u => u.UsuarioSugestacao)
                                    .ToListAsync();

            return _mapper.Map<List<ReturnSugestaoDto>>(entityList);
        }

        public async Task<ReturnSugestaoDto> GetById(int Id)
        {
            var entity = await _context.Sugestao
                                .Include(m => m.Maquina)
                                .SingleOrDefaultAsync(x => x.Id == Id);


            return _mapper.Map<ReturnSugestaoDto>(entity);
        }

        public async Task<List<ReturnSugestaoDto>> GetByMaquinaId(Guid id)
        {
            var entityList = await _context.Sugestao
                                            .Where(x =>
                                            x.MaquinaId == id)
                                            .ToListAsync();

            return _mapper.Map<List<ReturnSugestaoDto>>(entityList);
        }

        public async Task<ReturnSugestaoDto> InsertSugestacao(InsertSugestaoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MaquinaSugestaoId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.DescricaoSugestao) ||
                string.IsNullOrWhiteSpace(dto.UsuarioSugestaoId.ToString()))
                throw new Exception("Campo(s) obrigatório(s) vazio(s)!");

            var entity = _mapper.Map<SugestacaoManutencaoModel>(dto);

            _context.Sugestao.Add(entity);

            await _context.SaveChangesAsync();

            return await GetById(entity.Id);



        }
    }
}
