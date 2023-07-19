namespace API.AUTH.Dto.Claims.ReturnWithLink
{
    public class ReturnTypeClaimsLinkDto
    {
        public ReturnTypeClaimsLinkDto() 
        {
            DataClaims = new List<DataListClaimsTypeDto>();
        }
        public int TotalClaims { get; set; }
        public List<DataListClaimsTypeDto> DataClaims { get; set; }
    }
}
