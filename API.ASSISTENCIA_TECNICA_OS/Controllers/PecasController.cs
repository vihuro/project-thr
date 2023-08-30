using API.ASSISTENCIA_TECNICA_OS.ContextBase;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/assistencia-tecnica/pecas")]
    public class PecasController : ControllerBase
    {
        private readonly Context _context;

        public PecasController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var obj = await _context.Pecas.ToListAsync();

                var teste = new List<PecasModel>();

                foreach(var item in obj)
                {
                    var newItem = new PecasModel()
                    {
                        Nome = item.Nome,
                        Preco = item.Preco,
                        Id = item.Id,
                    };
 
                    if(item.EnderecoImagem.Count > 0)
                    {
                        newItem.EnderecoImagem = new List<string>();
                        foreach(var imagem in item.EnderecoImagem)
                        {
                            //listImagem.Add($"http://{item}");
                            newItem.EnderecoImagem.Add($"{imagem}");
                        }
                    }
                    teste.Add(newItem);
                }


                /*var newObj = new List<PecasModel>();
                foreach(var item in obj)
                {
                    if(item.EnderecoImagem.Count > 0)
                    {
                        foreach (var itemImage in item.EnderecoImagem) 
                        {
                            item.EnderecoImagem.Add($"http://{itemImage}");
                        }
                    }
                    newObj.Add(item);
                }*/
                return Ok(teste);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("image/{caminho}")]
        public ActionResult GetImage(string caminho)
        {
            try
            {

                var path = Path.Combine(caminho);
                if (!System.IO.File.Exists(path))
                {
                    return NotFound();
                }
                string mimeType = "image/jpg";
                return File(System.IO.File.OpenRead(path), mimeType, Path.GetFileName(path));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert(PecasModel dto)
        {
            try
            {
                var obj = new PecasModel
                {
                    EnderecoImagem = dto.EnderecoImagem,
                    Nome = dto.Nome,
                    Preco = dto.Preco,
                };
                _context.Pecas.Add(obj);
                await _context.SaveChangesAsync();
                return Created("", obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            try
            {
                var list = await _context.Pecas.ToListAsync();
                _context.Pecas.RemoveRange(list);
                await _context.SaveChangesAsync();
                return Ok(true);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
