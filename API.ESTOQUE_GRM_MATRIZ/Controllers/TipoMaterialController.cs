using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.TipoMaterial;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ESTOQUE_GRM_MATRIZ.Controllers
{
    [Route("api/v1/estoque/tipo-material")]
    [ApiController]
    public class TipoMaterialController : ControllerBase
    {
        private readonly ITipoService _service;

        public TipoMaterialController(ITipoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnType>> Insert(InsertTypeDto dto)
        {
            try
            {
                var result = await _service.Insert(dto);
                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReturnType>>> GetAll(Guid id)
        {
            try
            {
                var result = await _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<ReturnType>> GetAll()
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
        [HttpDelete]
        public async Task<ActionResult<List<ReturnType>>> DeleteAll()
        {
            try
            {
                var result = await _service.DelteAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
