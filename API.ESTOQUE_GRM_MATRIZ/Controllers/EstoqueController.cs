using API.AUTH.Service.JWT;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.ESTOQUE_GRM_MATRIZ.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;

        public EstoqueController(IEstoqueService service)
        {
            _service = service;
        }

        [HttpPost]
        [ClaimsAuthorizeAttribute("ESTOQUE - GRM - MATRIZ","TI,DIRETORIA,EXPEDIÇÃO - ALTERAÇÃO")]
        public async Task<ActionResult<ReturnEstoqueDto>> Insert(InsertEstoqueDto dto)
        {
            try
            {
                var result = await _service.Insert(dto);
                return Created("",result);
            }
            catch (Exception ex)
            {
                if(ex.HResult == 400) return BadRequest(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ClaimsAuthorizeAttribute("ESTOQUE - GRM - MATRIZ", "TI,DIRETORIA,EXPEDIÇÃO - ALTERAÇÃO,COMUNICADOR - LEITURA")]

        public async Task<ActionResult<List<ReturnEstoqueDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [ClaimsAuthorizeAttribute("ESTOQUE - GRM - MATRIZ", "TI,DIRETORIA,EXPEDIÇÃO - ALTERAÇÃO")]
        public async Task<ActionResult<ReturnEstoqueDto>> UpdateUnidadeOrTipo(UpdateQuantidadeOrUnidadeDto dto)
        {
            try
            {
                var result = await _service.UpdateQuantidadeOrUnidade(dto);
                return Ok(result);

            }
            catch (Exception ex)
            {
                if(ex.HResult == 404) return NotFound(ex.Message);
                if (ex.HResult == 400) return BadRequest(ex.Message);

                return BadRequest(ex.Message);
            }

        }
        [HttpPut("preco")]
        [ClaimsAuthorizeAttribute("ESTOQUE - GRM - MATRIZ", "TI,DIRETORIA")]
        public async Task<ActionResult<ReturnEstoqueDto>> UpdatePreco(UpdatePrecoDto dto)
        {
            try
            {
                var result = await _service.UpdatePreco(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                if (ex.HResult == 400) return BadRequest(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnEstoqueDto>>> GetById(int id)
        {
            try
            {
                var result = await _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if(ex.HResult == 404) return NotFound(ex.Message);
                if (ex.HResult == 400) return BadRequest(ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpGet("without-substituto/{id}")]
        [ClaimsAuthorizeAttribute("ESTOQUE - GRM - MATRIZ", "TI,DIRETORIA,EXPEDIÇÃO - ALTERAÇÃO")]
        public async Task<ActionResult<List<ReturnEstoqueDto>>> GetWithoutSubstituto(int id)
        {
            try
            {
                var result = await _service.GetWithoutSubstituto(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                if (ex.HResult == 400) return BadRequest(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [ClaimsAuthorizeAttribute("ESTOQUE - GRM - MATRIZ", "TI")]
        public async Task<ActionResult<bool>> DeteleAll()
        {
            try
            {
                var result = await _service.DeleteAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
