using API.AUTH.Dto.user;
using AuthUser.MessageBus;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace API.AUTH.RabbitMQSender
{
    public class RabbitMQMessageSender : IRabbitMQMessageSender
    {
        private readonly string _hostName;
        private readonly string _password;
        private readonly string _username;
        private IConnection _connection;

        public RabbitMQMessageSender()
        {
            _hostName = "some-rabbit";
            _password = "guest";
            _username = "guest";
        }

        public void SendMessage(BaseMessage baseMessage, string queueName)
        {
            var factoty = new ConnectionFactory()
            {
                HostName = _hostName,
                UserName = _username,
                Password = _password,
                Port = 5672
            };
            _connection = factoty.CreateConnection();
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);

            byte[] body = GetMessageAsByteArray(baseMessage);

            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

 
        }

        private static byte[] GetMessageAsByteArray(BaseMessage baseMessage)
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize((ReturnUserDto)baseMessage,option);

            var body = Encoding.UTF8.GetBytes(json);

            return body;

        }
    }
}
