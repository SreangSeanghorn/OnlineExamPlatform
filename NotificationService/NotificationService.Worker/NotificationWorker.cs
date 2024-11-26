using Microsoft.Extensions.Hosting;
using NotificationService.Infrastructure.Consumers;

namespace NotificationService.Worker
{
    public class NotificationWorker : BackgroundService
    {
        private readonly KafkaConsumer _consumer;

        public NotificationWorker(KafkaConsumer consumer)
        {
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumer.StartConsumingAsync(stoppingToken);
        }
    }
}
