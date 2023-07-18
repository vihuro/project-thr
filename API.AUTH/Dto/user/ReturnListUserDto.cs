using API.AUTH.Dto.user.ReturnWithLink;

namespace API.AUTH.Dto.user
{
    public class ReturnListUserDto
    {
        public ReturnListUserDto() 
        {
            DataUsers = new List<DataListUsersDto>();
        }
        public int TotalUsers { get; set; }
        public List<DataListUsersDto> DataUsers { get; set; }
    }
}
