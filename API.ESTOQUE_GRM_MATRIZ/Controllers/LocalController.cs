using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.ESTOQUE_GRM_MATRIZ.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ILocaleService _service;

        public LocalController(ILocaleService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnLocaleDto>> Insert(InsertLocale dto)
        {
            try
            {
                var result = await _service.Insert(dto);

                return Created("",result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnEstoqueDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                var response = new
                {
                    TotalItems = result.Count(),
                    Data = result
                };
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnEstoqueDto>> GetById(Guid id)
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
    }
}
