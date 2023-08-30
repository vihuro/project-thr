using System.Runtime.InteropServices;

namespace API.ASSISTENCIA_TECNICA_OS.Utils
{
    public class VerifyPlatform
    {
        public OSPlatform GetPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return OSPlatform.Windows;

            return OSPlatform.Linux;
        }
    }
}
