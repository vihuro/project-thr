namespace API.ASSISTENCIA_TECNICA_OS.Service.ExceptionService
{
    public class CustomException : Exception
    {
        public CustomException(string message): base(message) { }
    }
}
