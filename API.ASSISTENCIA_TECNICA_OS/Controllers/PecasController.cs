using API.ASSISTENCIA_TECNICA_OS.DTO.Pecas;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Model.Maquinas.Pecas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private static readonly NtlmPasswordAuthentication auth = new(null, "thr", "thr1");

        public PecasController(IPecaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReturnPecasDto>>> GetAll()
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
                    string smbPath = $"smb:{path.Replace("\\", "//").ReplaceAll("//", "/")}"; //"smb://192.168.2.24/api_assistencia_tecnica/Imagens/rolamento.jpg"; 

                    //NtlmPasswordAuthentication auth = new(null, "thr", "thr1");

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
        [HttpPost]
        public async Task<ActionResult<ReturnPecasDto>> Insert(InsertPecaDto dto)
        {
            try
            {
                var restult = await _service.InsertPecas(dto);

                return Created("", restult);
            }
            catch (Exception ex)
            {

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
