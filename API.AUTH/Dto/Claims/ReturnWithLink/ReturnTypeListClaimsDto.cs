namespace API.AUTH.Dto.Claims.ReturnWithLink
{
    public class ReturnTypeListClaimsDto
    {

        public int TotalClaims { get; set; }
        public List<ReturnTypeClaimsDto> DataClaims { get; set; }
    }
}
