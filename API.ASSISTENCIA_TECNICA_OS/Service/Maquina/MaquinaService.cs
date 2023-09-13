﻿using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.auth.Service.ExceptionService;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Maquina
{
    public class MaquinaService : IMaquinaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MaquinaService(Context context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                .AsNoTracking()
                .ToListAsync();

            var dto = _mapper.Map<List<ReturnMaquinaComPecasDto>>(list);

            return dto;
        }

        public async Task<ReturnMaquinaComPecasDto> GetById(Guid id)
        {
            var obj = await _context.Maquina
                .Include(u => u.UsuarioCadastro)
                .Include(u => u.UsuarioAlteracao)
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
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.NumeroSerie == numeroSerie) ??
                throw new CustomException("Máquina não encontrada!") { HResult = 404 };

            var dto = _mapper.Map<ReturnMaquinaComPecasDto>(obj);

            return dto;
        }

        public async Task<ReturnMaquinaComPecasDto> Insert(InsertMaquinaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TipoMaquina) ||
                string.IsNullOrWhiteSpace(dto.NumeroSerie) ||
                string.IsNullOrWhiteSpace(dto.UserId.ToString()))
                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };

            var verify = await _context.Maquina
                .AsNoTracking()
                .AnyAsync(x => x.NumeroSerie == dto.NumeroSerie);
            if (verify)
                throw new CustomException("Número de série já cadastrado!") { HResult = 400 };

            var obj = _mapper.Map<MaquinaModel>(dto);
            _context.Maquina.Add(obj);

            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
    }
}