﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ESTOQUE_GRM_MATRIZ.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class SubstitutosController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get() => "Aqui";
    }
}
