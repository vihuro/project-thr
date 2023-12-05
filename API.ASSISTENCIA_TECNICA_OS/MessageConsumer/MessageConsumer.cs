using API.ASSISTENCIA_TECNICA_OS.DTO.Maquina;
using API.ASSISTENCIA_TECNICA_OS.Interface;
using API.ASSISTENCIA_TECNICA_OS.Utils;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace API.ASSISTENCIA_TECNICA_OS.MessageConsumer
{
    public class MessageConsumer : IMessageConsumer, IDisposable
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly RabbitMQConfig _rabbitConfig;
        private readonly IServiceProvider _serviceProvider;

        public MessageConsumer(IServiceProvider serviceProvider,IOptions<RabbitMQConfig> rabbitConfig)
        {
            _serviceProvider = serviceProvider;
            _rabbitConfig = rabbitConfig.Value;

            CreateConnection();
        }
        public void CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitConfig.HostName,
                UserName = _rabbitConfig.UserName,
                Password = _rabbitConfig.Password
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_rabbitConfig.ExchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(_rabbitConfig.Queues[0].QueueName, false, false, false, null);

            _channel.QueueBind(_rabbitConfig.Queues[0].QueueName, 
                                _rabbitConfig.ExchangeName, 
                                _rabbitConfig.Queues[0].RoutingKey);
        }
        public async Task ReadMessage()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (chanel, eventArgs) =>
            {
                var content = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var user = JsonSerializer.Deserialize<UserDto>(content);

                var _userService = _serviceProvider.CreateScope()
                                        .ServiceProvider.GetRequiredService<IUserService>();

                await _userService.Insert(user);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            _channel.BasicConsume(_rabbitConfig.Queues[0].QueueName, false, consumer);

            await Task.CompletedTask;
        }

        public void Dispose()
        {
            if(_channel.IsOpen) _channel.Close();
            if(_connection.IsOpen) _connection.Close();
        }
    }
}
