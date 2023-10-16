﻿using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Orcamento;
using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Peca
{
    public class PecaService : IPecaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IPecasRadarService _radarPecasService;

        public PecaService(Context context,
                            IMapper mapper,
                            IPecasRadarService pecasSerice)
        {
            _context = context;
            _mapper = mapper;
            _radarPecasService = pecasSerice;
        }

        public Task<bool> DeleteAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnPecasDto> GetAll(int skip, int take)
        {
            var obj = await _context.Pecas
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .AsNoTracking()
                .OrderBy(c => c.CodigoRadar)
                .Skip(skip)
                .Take(take)
                .OrderBy(x => x.CodigoRadar)
                .ToListAsync() ??

                throw new CustomException("Peça não encontrada!") { HResult = 404 };

            var total = await _context.Pecas.CountAsync();
            var mapper = _mapper.Map<List<PecasDto>>(obj);
            var dto = new ReturnPecasDto
            {
                Total = total,
                QuantityPages = total /= take
            };
            dto.CurrentPage = skip / take + 1;
            dto.Pecas = mapper;

            return dto;
        }
        public async Task<ReturnPecasDto> GetWithFilter(FilterPecasDto dto)
        {

            var obj = await _context.Pecas
                .Where(p => p.Unidade.ToUpper().Contains(dto.Unidade.ToUpper()) &&
                p.CodigoRadar.ToUpper().Contains(dto.CodigoRadar.ToUpper()) &&
                p.Descricao.ToUpper().Contains(dto.Descricao.ToUpper()) &&
                p.Familia.ToUpper().Contains(dto.Familia.ToUpper()))
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
                .ToListAsync();

            var mapper = _mapper.Map<ReturnPecasDto>(obj);

            return mapper;
        }

        public async Task<ReturnPecasDto> GetById(Guid id)
        {
            var obj = await _context.Pecas
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id) ??

                throw new CustomException("Peça não encontrada!") { HResult = 404 };

            return _mapper.Map<ReturnPecasDto>(obj);

        }

        public async Task<ReturnPecasDto> InsertPecas(Guid idUsuario)
        {
            var listRadar = await _radarPecasService.GetPecas();

            var listObj = await _context.Pecas.ToListAsync();

            var verify = listRadar
                .Where(x => !listObj.Any(c => c.CodigoRadar == x.Codigo))
                .ToList();

            var newList = new List<PecasModel>();

            foreach (var item in verify)
            {
                newList.Add(new PecasModel
                {
                    Descricao = item.Descricao,
                    CodigoRadar = item.Codigo,
                    Familia = item.Familia,
                    Preco = 0,
                    Unidade = item.Unidade,
                    DataHoraCadastro = DateTime.UtcNow,
                    DataHoraAlteracao = DateTime.UtcNow,
                    UsuarioCadastroId = idUsuario,
                    UsuarioAlteracaoId = idUsuario
                });
            }
            _context.Pecas.AddRange(newList);
            await _context.SaveChangesAsync();

            var mapper = _mapper.Map<List<PecasDto>>(newList);

            var dto = new ReturnPecasDto
            {
                CurrentPage = 0,
                QuantityPages = 1,
                Pecas = mapper,
                Total = newList.Count
            };

            return dto;
        }
        public async Task<ReturnPecasDto> GetRadar()
        {
            var objList = await _radarPecasService.GetPecas();
            var infoPecas = new ReturnPecasDto();
            var list = new List<PecasDto>();
            foreach (var item in objList)
            {
                list.Add(new PecasDto
                {
                    CodigoRadar = item.Codigo,
                    Familia = item.Familia,
                    Unidade = item.Unidade,
                    Descricao = item.Descricao
                });
            }
            infoPecas.Pecas = list.OrderBy(x => x.CodigoRadar).ToList();

            return infoPecas;
        }
        public async Task<ReturnPecasDto> GetNotRegister()
        {
            var radarList = await _radarPecasService.GetPecas();
            var objList = await _context.Pecas.ToListAsync();

            var verify = radarList.Where(x => !objList.Any(c => c.CodigoRadar == x.Codigo)).ToList();

            var infoPecas = new ReturnPecasDto();
            var list = new List<PecasDto>();
            foreach (var item in verify)
            {
                list.Add(new PecasDto
                {
                    CodigoRadar = item.Codigo,
                    Familia = item.Familia,
                    Unidade = item.Unidade,
                    Descricao = item.Descricao
                });
            }
            infoPecas.Pecas = list.OrderBy(x => x.CodigoRadar).ToList();

            return infoPecas;
        }


        /*public async Task<ReturnPecasDto> InsertPecas(InsertPecaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Preco.ToString()) ||
                string.IsNullOrWhiteSpace(dto.Descricao) ||
                string.IsNullOrWhiteSpace(dto.CodigoRadar))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var existis = _context.Pecas
                .Any(x => x.CodigoRadar == dto.CodigoRadar.ToUpper());
            if (existis)
                throw new CustomException("CÓDIGO JÁ CADASTRADO!");

            var obj = _mapper.Map<PecasModel>(dto);

            _context.Pecas.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }*/
        public async Task<ReturnPecasDto> Update(UpdatePecaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Preco.ToString()) ||
                string.IsNullOrWhiteSpace(dto.Descricao) ||
                string.IsNullOrWhiteSpace(dto.CodigoRadar))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var existis = _context.Pecas
                .Any(x => x.CodigoRadar == dto.CodigoRadar.ToUpper() && x.Id != dto.PecaId);
            if (existis)
                throw new CustomException("CÓDIGO JÁ CADASTRADO!");
            var obj = await _context.Pecas.SingleOrDefaultAsync(x => x.Id == dto.PecaId) ??
                throw new CustomException("PEÇA NÃO ENCONTRADA!") { HResult = 404 };

            obj.Descricao = dto.Descricao.ToUpper();
            obj.CodigoRadar = dto.CodigoRadar.ToUpper();
            obj.UsuarioAlteracaoId = dto.UsuarioId;
            obj.DataHoraAlteracao = DateTime.UtcNow;
            obj.EnderecoImagem = dto.EnderecoImagem;

            _context.Pecas.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);

        }
    }
}
