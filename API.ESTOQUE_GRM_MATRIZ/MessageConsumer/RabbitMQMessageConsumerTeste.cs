using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Service.User;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace API.ESTOQUE_GRM_MATRIZ.MessageConsumer
{
    public class RabbitMQMessageConsumerTeste : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly UserService _service;

        public RabbitMQMessageConsumerTeste(UserService service)
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
            _channel.QueueDeclare(queue: "update-user-active-estoque-grm-matriz", false, false, false, arguments: null);

        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (chanel, eventArgs) =>
            {
                var content = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var user = JsonSerializer.Deserialize<UserDto>(content);

                if (eventArgs.RoutingKey == "insert-user-estoque-grm-matriz")
                {
                    await _service.Inset(user);
                }
                else if (eventArgs.RoutingKey == "update-user-active-estoque-grm-matriz")
                {
                    await _service.Change(user);
                }

                _channel.BasicAck(eventArgs.DeliveryTag, false);


            };

            _channel.BasicConsume("insert-user-estoque-grm-matriz", false, consumer);
            _channel.BasicConsume("update-user-active-estoque-grm-matriz", false, consumer);
            return Task.CompletedTask;
        }
    }
}
