using API.ESTOQUE_GRM_MATRIZ.Dto.Estoque.Movimentacao;
using API.ESTOQUE_GRM_MATRIZ.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.ESTOQUE_GRM_MATRIZ.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoService _movimentacaoService;

        public MovimentacaoController(IMovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReturnMovimentacao>>> GetAll()
        {
            try
            {
                var result = await _movimentacaoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult<List<ReturnMovimentacao>>> GetById(Guid id)
        {
            try
            {
                var result = await _movimentacaoService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("material-id/{id}")]
        public async Task<ActionResult<List<ReturnMovimentacao>>> GetByMaterialId(Guid id)
        {
            try
            {
                var result = await _movimentacaoService.GetByMaterialId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<ActionResult<List<ReturnMovimentacao>>> UpdateQuantidadeEstoque(UpdateMovimentacaoQuantidadeDto dto)
        {
            try
            {
                var result = await _movimentacaoService.Insert(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                if(ex.HResult == 400) return BadRequest(ex.Message);

                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAll()
        {
            try
            {
                var result = await _movimentacaoService.DeleteAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                if (ex.HResult == 400) return BadRequest(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
