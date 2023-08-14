using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ESTOQUE_GRM_MATRIZ.Controllers
{
    [Route("api/v1/estoque/[controller]")]
    [ApiController]
    public class SubstitutosController : ControllerBase
    {
        private readonly ISubstitutosService _service;

        public SubstitutosController(ISubstitutosService service)
        {
            _service = service;
        }

        [HttpPut]
        public async Task<ActionResult<ReturnSubstitutoDto>> UpdateSubstituto(UpdateSubstitutoDto dto)
        {
            try
            {
                var result = await _service.UpdateSubstituto(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404)
                    return NotFound(ex.Message);

                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnSubstitutoDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnSubstitutoDto>>> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAll()
        {
            try
            {
                var result = await _service.DeleteAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpDelete("unico")]
        public async Task<ActionResult<bool>> DeleteById(DeleteSubstitutoById dto)
        {
            try
            {
                var result = await _service.DeleteById(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex);
            }
        }
    }
}
