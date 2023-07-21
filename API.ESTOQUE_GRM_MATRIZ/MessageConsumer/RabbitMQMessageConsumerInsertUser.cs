using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Service.User;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace API.ESTOQUE_GRM_MATRIZ.MessageConsumer
{
    public class RabbitMQMessageConsumerInsertUser : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly UserService _service;

        public RabbitMQMessageConsumerInsertUser(UserService service)
        {
            _service = service;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "insert-user-estoque-grm-matriz", false, false, false, arguments: null);

   
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (chanel, eventArgs) =>
            {
                var content = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var user = JsonSerializer.Deserialize<UserDto>(content);

                _channel.BasicAck(eventArgs.DeliveryTag, false);


                await _service.Inset(user);


            };

            _channel.BasicConsume("insert-user-estoque-grm-matriz", false, consumer);

            return Task.CompletedTask;

        }
    }
}
