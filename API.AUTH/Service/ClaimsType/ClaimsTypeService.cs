using API.AUTH.ContextBase;
using API.AUTH.Dto.Claims;
using API.AUTH.Interface;
using API.AUTH.Models.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using THR.auth.Service.ExceptionService;

namespace API.AUTH.Service.ClaimsType
{
    public class ClaimsTypeService : IClaimsTypeService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ClaimsTypeService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReturnTypeClaimsDto> Insert(RegisterClaimDto dto)
        {
            if (await VerifyClaim(dto.Value, dto.Name))
                throw new CustomException("Regra já existente!");

            if (string.IsNullOrWhiteSpace(dto.Value) ||
                string.IsNullOrWhiteSpace(dto.Name) ||
                string.IsNullOrWhiteSpace(dto.UsuarioId.ToString()))

                throw new CustomException("Campo(s) obrigatório(s) vazio(s)!");

            var obj = _mapper.Map<RegisterClaimDto, TypeClaimsModel>(dto);

            _context.TyepClaimsModel.Add(obj);
            await _context.SaveChangesAsync();


            return _mapper.Map<TypeClaimsModel, ReturnTypeClaimsDto>(obj);

        }
        public async Task<List<ReturnTypeClaimsDto>> GetAll()
        {
            var obj = await _context.TyepClaimsModel
                .Include(u => u.UsuarioAlteracao)
                .Include(u => u.UsuarioCadastro)
                .ToListAsync();

            return _mapper.Map<List<TypeClaimsModel>, List<ReturnTypeClaimsDto>>(obj);

        }

        public Task<ReturnTypeClaimsDto> Update(RegisterClaimDto dto)
        {
            throw new NotImplementedException();
        }
        private async Task<bool> VerifyClaim(string ClaimValue, string ClaimName)
        {
            var claim = await _context.TyepClaimsModel
                .FirstOrDefaultAsync(x => x.Name == ClaimName.ToUpper() && x.Value == ClaimValue.ToUpper());
            if (claim == null) return false;

            return true;
        }

        public async Task<ReturnTypeClaimsDto> GetById(Guid id)
        {
            var claim = await _context.TyepClaimsModel
                .FirstOrDefaultAsync(x => x.Id == id) ??
            throw new CustomException("Regra não encontrada!") { HResult = 404 };

            return _mapper.Map<TypeClaimsModel, ReturnTypeClaimsDto>(claim);
        }

        public async Task<ReturnTypeClaimsDto> GetByName(string ClaimName)
        {
            var claim = await _context.TyepClaimsModel
                .FirstOrDefaultAsync(x => x.Name == ClaimName.ToUpper()) ??
            throw new CustomException("Regra não encontrada!") { HResult = 404 };

            return _mapper.Map<TypeClaimsModel, ReturnTypeClaimsDto>(claim);
        }

        public async Task<ReturnTypeClaimsDto> GetByValue(string ClaimValue)
        {
            var claim = await _context.TyepClaimsModel
                .FirstOrDefaultAsync(x => x.Value == ClaimValue.ToUpper()) ??
            throw new CustomException("Regra não encontrada!") { HResult = 404 };

            return _mapper.Map<TypeClaimsModel, ReturnTypeClaimsDto>(claim);
        }

        public async Task<ReturnTypeClaimsDto> GetByValueAndName(string ClaimValue, string ClaimName)
        {
            var claim = await _context.TyepClaimsModel
                .FirstOrDefaultAsync(x => x.Value == ClaimValue.ToUpper() && x.Name == ClaimName) ??
            throw new CustomException("Regra não encontrada!") { HResult = 404 };

            return _mapper.Map<TypeClaimsModel, ReturnTypeClaimsDto>(claim);
        }
    }
}
