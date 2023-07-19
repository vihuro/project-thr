using API.AUTH.Dto.Link;

namespace API.AUTH.Dto.Claims.ReturnWithLink
{
    public class DataListClaimsTypeDto
    {
        public ReturnTypeClaimsDto Claim { get; set; }
        public List<LinkDto> Links { get; set; }
    }
}
