namespace API.AUTH.Utils
{
    public sealed class RabbitMQConfig
    {
        public string ExchangeName{get;set;}
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public List<QueueList> Queues { get; set; }
    }
    public sealed class QueueList
    {
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
    }
}
