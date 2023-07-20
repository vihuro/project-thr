using API.AUTH.ContextBase;
using API.AUTH.Dto.ClaimsForUser;
using API.AUTH.Dto.user;
using API.AUTH.Interface;
using API.AUTH.Models.Claims;
using API.AUTH.Models.User;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using THR.auth.Service.ExceptionService;

namespace API.AUTH.Service
{
    public class ClaimsForUserService : IClaimsForUserService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IClaimsTypeService _claimsTypeService;

        public ClaimsForUserService(Context context, 
                                    IMapper mapper,
                                    IUserService userService,
                                    IClaimsTypeService claimsTypeService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _claimsTypeService = claimsTypeService;
        }

        public async Task<ReturnClaimsForUserDto> Insert(InsertClaimsForUserDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.UserRegisterId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.UserClaimsId.ToString()) ||
                string.IsNullOrWhiteSpace(dto.ClaimId.ToString()))

                throw new CustomException("Campo(s) obrigatótio(s) vazio(s)!");
            

            var obj = _mapper.Map<InsertClaimsForUserDto, ClaimsForUserModel>(dto);
            var userClaim = await _userService.ChangeDateTimeChange(dto.UserClaimsId);

            var listClaims = await _claimsTypeService.GetAll();

            var existingClaim = userClaim.Claims.FirstOrDefault(c => listClaims.Any(x => x.ClaimName == c.ClaimName));

            if (existingClaim != null)
            {
                obj.Id = existingClaim.id;
                obj.TypeClaimsId = dto.ClaimId;
            }

            _context.ClaimsForUserModel.Update(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
        public async Task<List<ReturnClaimsForUserDto>> GetAll()
        {
            var obj = await _context.ClaimsForUserModel
                .Include(u => u.UserChange)
                .Include(u => u.UserClaim)
                .Include(c => c.TypeClaims)
                .ToListAsync();


            return _mapper.Map<List<ClaimsForUserModel>, List<ReturnClaimsForUserDto>>(obj);
        }
        public async Task<ReturnClaimsForUserDto> GetById(Guid id)
        {
            var obj = await _context.ClaimsForUserModel
                .Include(u => u.UserChange)
                .Include(u => u.UserClaim)
                .Include(c => c.TypeClaims)
                .FirstOrDefaultAsync(x => x.Id == id) ??
                throw new CustomException("Usuário não encontrado!") { HResult = 404 };

            return _mapper.Map<ClaimsForUserModel, ReturnClaimsForUserDto>(obj);
        }
        public async Task<List<ReturnClaimsForUserDto>> GetByClaimId(Guid id)
        {
            var obj = await _context.ClaimsForUserModel
                .Include(u => u.UserChange)
                .Include(u => u.UserClaim)
                .Include(c => c.TypeClaims)
                .Where(x => x.TypeClaimsId == id)
                .ToListAsync() ??
                throw new CustomException("Regra não encontrada!") { HResult = 404 };

            return _mapper.Map<List<ClaimsForUserModel>, List<ReturnClaimsForUserDto>>(obj);
        }
        public async Task<List<ReturnClaimsForUserDto>> GetByUserId(Guid id)
        {
            var obj = await _context.ClaimsForUserModel
                .Include(u => u.UserChange)
                .Include(u => u.UserClaim)
                .Include(c => c.TypeClaims)
                .Where(x => x.UserClaimId == id)
                .ToListAsync() ??
                throw new CustomException("Usuário não econtrado!") { HResult = 404 };

            return _mapper.Map<List<ClaimsForUserModel>, List<ReturnClaimsForUserDto>>(obj);
        }
        public async Task<bool> DeleteAll()
        {
            var obj = await _context.ClaimsForUserModel
                .ToListAsync();
            _context.ClaimsForUserModel.RemoveRange(obj);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
