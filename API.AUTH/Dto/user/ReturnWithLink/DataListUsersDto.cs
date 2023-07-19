using API.AUTH.Dto.Link;

namespace API.AUTH.Dto.user.ReturnWithLink
{
    public class DataListUsersDto
    {
        public ReturnUserDto User { get; set; }
        public List<LinkDto> Link { get; set; }

    }
}
