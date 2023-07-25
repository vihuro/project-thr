using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque;
using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Substituto;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ESTOQUE_GRM_MATRIZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;

        public EstoqueController(IEstoqueService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnEstoqueDto>> Insert(InsertEstoqueDto dto)
        {
            try
            {
                var result = await _service.Insert(dto);
                return Ok(result);
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
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnEstoqueDto>>> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeteleAll()
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
