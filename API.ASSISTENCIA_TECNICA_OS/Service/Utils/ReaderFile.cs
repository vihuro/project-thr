using API.ASSISTENCIA_TECNICA_OS.Utils;
using Microsoft.Extensions.Options;
using SharpCifs.Smb;
using SharpCifs.Util.Sharpen;
using System.Runtime.InteropServices;
using System.Text;

namespace API.ASSISTENCIA_TECNICA_OS.Service.Utils
{
    public class ReaderFile
    {

        private static readonly string _path = "\\\\192.168.2.24\\api_assistencia_tecnica\\Reports\\THR_PROD_ASSTEC.txt";
        private static NtlmPasswordAuthentication auth;

        private readonly IConfiguration _configuration;
        private static AndressReports _andressReports;

        public ReaderFile(IConfiguration configuration, IOptions<AndressReports> andressReports)
        {
            _configuration = configuration;
            _andressReports = andressReports.Value;
            auth = new NtlmPasswordAuthentication(null, andressReports.Value.User, andressReports.Value.Password);
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
            string smbPath = $"smb:{_andressReports.Andress.Replace("\\", "//").ReplaceAll("//", "/")}";
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
