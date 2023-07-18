namespace THR.auth.Service.ExceptionService
{
    public class CustomException : Exception
    {
        public CustomException(string message): base(message) { }
    }
}
