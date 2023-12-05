using API.ASSISTENCIA_TECNICA_OS.Interface;

namespace API.ASSISTENCIA_TECNICA_OS.Utils
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IMessageConsumer _messageConsumer;

        public ConsumerHostedService(IMessageConsumer messageConsumer)
        {
            _messageConsumer = messageConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _messageConsumer.ReadMessage();
        }
    }
}
