using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaismController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetAll() => "Olá mundo";
    }
}
