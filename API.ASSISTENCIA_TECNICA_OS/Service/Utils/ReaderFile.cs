using SharpCifs.Smb;
using SharpCifs.Util.Sharpen;
using System.Runtime.InteropServices;
using System.Text;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Utils
{
    public class ReaderFile
    {

        private static readonly string _path = "\\\\192.168.43.186\\api_assitencia_tecnica\\Reports\\THR_PROD_ASSTEC.txt";
        private static readonly NtlmPasswordAuthentication auth = new(null, "vitor", "25249882");

        public StreamReader GetFileReader()
        {
            if (VerifyPlatform() == OSPlatform.Windows) return ReaderInWindows();

            return ReaderInLinux();
        }

        private static StreamReader ReaderInWindows()
        {
            return new StreamReader(_path, Encoding.GetEncoding("ISO-8859-1"), true);

        }
        private static StreamReader ReaderInLinux()
        {
            string smbPath = $"smb:{_path.Replace("\\", "//").ReplaceAll("//", "/")}";
            var smb = new SmbFile(smbPath, auth).GetInputStream();
            return new StreamReader(smb, Encoding.GetEncoding("ISO-8859-1"), true);

        }
        private static OSPlatform VerifyPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return OSPlatform.Windows;

            return OSPlatform.Linux;
        }
    }

}
