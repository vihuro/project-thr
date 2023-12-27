using API.ASSISTENCIA_TECNICA_OS.Utils;
using Microsoft.Extensions.Options;
using SharpCifs.Util.Sharpen;
using System.Runtime.InteropServices;
using System.Text;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Utils
{
    public class ReaderFile
    {
        private static AndressReports _andressReports;

        public ReaderFile(IConfiguration configuration, IOptions<AndressReports> andressReports)
        {
            _andressReports = andressReports.Value;
        }

        public StreamReader GetFileReader()
        {
            if (VerifyPlatform() == OSPlatform.Windows) return ReaderInWindows();

            return ReaderInLinux();
        }

        private static StreamReader ReaderInWindows()
        {
            return new StreamReader(_andressReports.Andress, Encoding.GetEncoding("ISO-8859-1"), true);

        }
        private static StreamReader ReaderInLinux()
        {
            var myString = _andressReports.Andress.Replace("\\", "//").ReplaceAll("//", "/");

            return new StreamReader(myString, Encoding.GetEncoding("ISO-8859-1"), true);

        }
        private static OSPlatform VerifyPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return OSPlatform.Windows;

            return OSPlatform.Linux;
        }
    }

}
