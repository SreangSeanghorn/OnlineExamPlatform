namespace NotificationService.Domain.Interfaces;

public interface IKafkaConsumer
{
    Task StartConsumingAsync(CancellationToken cancellationToken);
}