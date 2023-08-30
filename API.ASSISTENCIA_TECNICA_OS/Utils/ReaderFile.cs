using System.Runtime.InteropServices;
using System.Text;
using SharpCifs.Smb;

namespace API.ASSISTENCIA_TECNICA_OS.Utils
{
    public class ReaderFile
    {
        private readonly VerifyPlatform verifyPlatform;

        public ReaderFile(VerifyPlatform verifyPlatform)
        {
            this.verifyPlatform = verifyPlatform;

        }
        public StreamReader GetFileReader(string caminho)
        {
            if (verifyPlatform.GetPlatform() == OSPlatform.Windows) return ReaderInWindows(caminho);
            return ReaderInLinux(caminho);
        }

        private static StreamReader ReaderInWindows(string caminho)
        {
            return new StreamReader(caminho, Encoding.GetEncoding("ISO-8859-1"), true);

        }
        private static StreamReader ReaderInLinux(string caminho)
        {
            var smb = new SmbFile(caminho).GetInputStream();
            return new StreamReader(smb, Encoding.GetEncoding("ISO-8859-1"), true);

        }
    }
}
