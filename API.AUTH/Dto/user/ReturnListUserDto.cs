namespace API.AUTH.Dto.user
{
    public class ReturnListUserDto
    {

        public int TotalUsers { get; set; }
        public List<ReturnUserDto> DataUsers { get; set; }
    }
}
