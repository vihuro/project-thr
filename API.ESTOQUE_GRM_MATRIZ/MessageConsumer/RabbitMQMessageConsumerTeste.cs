using API.ESTOQUE_GRM_MATRIZ.Dto.UserAuth;
using API.ESTOQUE_GRM_MATRIZ.Service.User;
using API.ESTOQUE_GRM_MATRIZ.Utils;
using Microsoft.Extensions.Options;
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
        private readonly RabbitMQConfig _rabbitConfig;
        private readonly UserService _userService;

        public RabbitMQMessageConsumerTeste(UserService userService, IOptions<RabbitMQConfig> rabbitConfig)
        {
            _rabbitConfig = rabbitConfig.Value;


            _userService = userService;

            var factory = new ConnectionFactory
            {
                HostName = _rabbitConfig.HostName,
                UserName = _rabbitConfig.UserName,
                Password = _rabbitConfig.Password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_rabbitConfig.ExchangeName, ExchangeType.Direct);

            _channel.QueueDeclare(queue: _rabbitConfig.Queues[0].QueueName, false, false, false, arguments: null);

            _channel.QueueBind(_rabbitConfig.Queues[0].QueueName, _rabbitConfig.ExchangeName, _rabbitConfig.Queues[0].RoutingKey);

        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();



            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (chanel, eventArgs) =>
            {
                var content = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var user = JsonSerializer.Deserialize<UserDto>(content);

                await _userService.Inset(user);

                _channel.BasicAck(eventArgs.DeliveryTag, false);

            };
            _channel.BasicConsume(_rabbitConfig.Queues[0].QueueName, false, consumer);

            return Task.CompletedTask;
        }
    }
}
