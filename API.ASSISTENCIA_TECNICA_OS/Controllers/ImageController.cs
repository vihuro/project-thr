using Microsoft.AspNetCore.Mvc;
using SharpCifs.Smb;
using SharpCifs.Util.Sharpen;
using System.IO;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace API.ASSISTENCIA_TECNICA_OS.Controllers
{
    [ApiController]
    [Route("api/v1/image")]
    public class ImageController : ControllerBase
    {
        private static readonly string caminho = "\\\\192.168.2.24\\api_assistencia_tecnica\\Imagens\\";

        private static readonly NtlmPasswordAuthentication auth = new(null, "thr", "thr1");

        [HttpGet]
        public async Task<ActionResult> GetFiles()
        {
            try
            {

                var isRunningOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

                if (!isRunningOnWindows)
                {
                    string smbPath = $"smb:{caminho.Replace("\\", "//").ReplaceAll("//", "/")}";
                    var smbFille = await new SmbFile(smbPath, auth).ListFilesAsync();

                    var list = new List<string>();

                    var listFile = smbFille.Select(c => c.GetName()).Order();


                    return Ok(listFile);
                }

                string[] path = Directory.GetFiles(caminho);

                var fileNames = path.Select(Path.GetFileName).ToList();

                return Ok(fileNames);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert([FromForm]FileDto file)
        {

            //var caminho = "\\\\192.168.0.187\\api_assitencia_tecnica\\imagens";

            var caminhoPath = $"{caminho}\\{file.Nome}";

            var isRunningOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (!isRunningOnWindows)
            {
                string smbPath = $"smb:{caminhoPath.Replace("\\", "//").ReplaceAll("//", "/")}";

                var smbFile = new SmbFile($"{smbPath}.jpg", auth);

                using (var stream = await smbFile.GetOutputStreamAsync())
                {
                    await file.File.CopyToAsync(stream);
                }


                return Ok("Upload bem-sucedido");
            }

            var fullPath = Path.Combine(caminho, $"{file.Nome}.jpg");


            using (var stream = new FileStream($"{caminhoPath}.jpg", FileMode.Create))
            {
                await file.File.CopyToAsync(stream);
            }

            return Ok("Upload bem-sucedido");


        }
        [HttpGet("{nome}")]
        public async Task<ActionResult> GetByNome(string nome)
        {
            try
            {
                //var caminho = $"\\\\192.168.0.187\\api_assitencia_tecnica\\imagens\\{nome}";

                var caminhoPath = $"{caminho}\\{nome}";

                var isRunningOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                string mimeType = "image/jpg";

                string path = caminho;
                if (!isRunningOnWindows)
                {
                    string smbPath = $"smb:{caminhoPath.Replace("\\", "//").ReplaceAll("//", "/")}"; //"smb://192.168.2.24/api_assistencia_tecnica/Imagens/rolamento.jpg"; 

                    var sbmFile = await new SmbFile(smbPath, auth).GetInputStreamAsync();

                    return File(sbmFile, mimeType);

                }

                if (!System.IO.File.Exists(caminhoPath))
                {
                    return NotFound();
                }

                return File(System.IO.File.OpenRead(caminhoPath), mimeType, Path.GetFileName(path));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public class FileDto
        {
            public string Nome { get; set; }
            public IFormFile File { get; set; }
        }
    }
}
