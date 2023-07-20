namespace AuthUser.MessageBus
{
    public class BaseMessage
    {
        public long IdMessage { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}
