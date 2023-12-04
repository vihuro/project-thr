using API.AUTH.Dto.user;
using API.AUTH.Utils;
using AuthUser.MessageBus;
using Microsoft.Extensions.Options;
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
        private readonly string _exchangeName = "DirectUserExchange";
        private readonly string _storageUserQueueName = "UserInStorageQueueName";
        private readonly string _assitecUserQueueName = "UserInAssistecQueueName";
        private readonly RabbitMQConfig _rabbitConfig;

        public RabbitMQMessageSender(IOptions<RabbitMQConfig> rabbitConfig)
        {
            _rabbitConfig = rabbitConfig.Value;
        }

        public void SendMessage(BaseMessage baseMessage, string queueName)
        {
            var factoty = new ConnectionFactory()
            {
                HostName = _rabbitConfig.HostName,
                UserName = _rabbitConfig.UserName,
                Password = _rabbitConfig.Password,
                Port = _rabbitConfig.Port
            };
            _connection = factoty.CreateConnection();
            using var channel = _connection.CreateModel();


            channel.ExchangeDeclare(_rabbitConfig.ExchangeName, ExchangeType.Direct, false);
            byte[] body = GetMessageAsByteArray(baseMessage);

            foreach (var item in _rabbitConfig.Queues)
            {
                channel.QueueDeclare(item.QueueName, false, false, false, null);
                channel.QueueBind(item.QueueName, _rabbitConfig.ExchangeName, item.RoutingKey);

                channel.BasicPublish(_rabbitConfig.ExchangeName, item.RoutingKey, null, body);
            }

        }

        private static byte[] GetMessageAsByteArray(BaseMessage baseMessage)
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize((ReturnUserDto)baseMessage, option);

            var body = Encoding.UTF8.GetBytes(json);

            return body;

        }
    }
}
