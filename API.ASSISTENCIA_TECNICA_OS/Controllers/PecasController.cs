using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using Microsoft.AspNetCore.Mvc;
using SharpCifs.Smb;
using SharpCifs.Util.Sharpen;
using System.Runtime.InteropServices;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/assistencia-tecnica/pecas")]
    public class PecasController : ControllerBase
    {

        private readonly IPecaService _service;

        private static readonly NtlmPasswordAuthentication auth = new(null, "vitor", "25249882");

        public PecasController(IPecaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<ReturnPecasDto>> GetAllWithoutSkip()
        {
            try
            {
                var result = await _service.GetWithoutSkip();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{skip}/{take}")]
        public async Task<ActionResult<List<ReturnPecasDto>>> GetAll(int skip = 0, int take = 20)
        {
            try
            {
                var result = await _service.GetAll(skip,take);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("with-filter/{skip}/{take}")]
        public async Task<ActionResult<List<ReturnPecasDto>>> GetWithFilter([FromQuery] FilterPecasDto dto,
            int skip = 0 ,
            int take = 20)
        {
            try
            {
                var result = await _service.GetWithFilter(dto,skip,take);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("radar")]
        public async Task<ActionResult<List<ReturnPecasDto>>> GetRadar()
        {
            try
            {
                var result = await _service.GetRadar();
                var obj = new
                {
                    total = result.Pecas.Count,
                    data = result.Pecas,
                };

                return Ok(obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("nao-cadastrados")]
        public async Task<ActionResult<List<ReturnPecasDto>>> GetNotRegister()
        {
            try
            {
                var result = await _service.GetNotRegister();
                var obj = new
                {
                    total = result.Pecas.Count,
                    data = result.Pecas
                };
                return Ok(obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("image/{caminho}")]
        public async Task<ActionResult> GetImage(string caminho)
        {
            try
            {
                var isRunningOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                string mimeType = "image/jpg";

                string path = caminho;
                if (!isRunningOnWindows)
                {
                    string smbPath = $"smb:{path.Replace("\\", "//").ReplaceAll("//", "/")}"; 


                    var sbmFile = await new SmbFile(smbPath, auth).GetInputStreamAsync();

                    return File(sbmFile, mimeType);

                }

                if (!System.IO.File.Exists(path))
                {
                    return NotFound();
                }

                return File(System.IO.File.OpenRead(path), mimeType, Path.GetFileName(path));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("list/{caminho}")]
        public async Task<ActionResult> GetPaths(string caminho)
        {
            try
            {
                var isRunningOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                string mimeType = "image/jpg";

                string path = caminho;
                if (!isRunningOnWindows)
                {
                    string smbPath = $"smb:{path.Replace("\\", "//").ReplaceAll("//", "/")}"; //"smb://192.168.2.24/api_assistencia_tecnica/Imagens/rolamento.jpg"; 

                    //NtlmPasswordAuthentication auth = new(null, "thr", "25249882");

                    var sbmFile = await new SmbFile(smbPath, auth).ListFilesAsync();


                    var fileList = new List<SmbFile>();
                    foreach (var file in sbmFile)
                    {
                        fileList.Add(file);
                    }
                    return Ok(fileList);

                }

                if (!System.IO.File.Exists(path))
                {
                    return NotFound();
                }

                return File(System.IO.File.OpenRead(path), mimeType, Path.GetFileName(path));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{idUsuario}")]
        public async Task<ActionResult<ReturnPecasDto>> Insert(Guid idUsuario)
        {
            try
            {
                var restult = await _service.InsertPecas(idUsuario);

                var obj = new
                {
                    total = restult.Pecas.Count,
                    data = restult
                };
                if(restult.Pecas.Count == 0)
                {
                    return Ok("Não há novos códigos para serem adicionados!");
                }

                return Created("", obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<ReturnPecasDto>> Update(UpdatePecaDto dto)
        {
            try
            {
                var result = await _service.Update(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.HResult == 404) return NotFound(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            try
            {
                var resutl = await _service.DeleteAll();



                return Ok(resutl);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
