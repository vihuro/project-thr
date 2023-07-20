using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ESTOQUE_GRM_MATRIZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get() => "aqui";
    }
}
