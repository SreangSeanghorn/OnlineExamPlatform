using System.Collections.Concurrent;
using Confluent.Kafka;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Infrastructure.Consumers;

public class KafkaConsumer
{
    private readonly INotificationHandler _handler;
    private readonly KafkaConsumerConfig _consumerConfig;
    private readonly ConcurrentDictionary<string, Func<string, Task>> _eventHandlers;

    public KafkaConsumer(
        INotificationHandler handler,
        KafkaConsumerConfig consumerConfig,
        IEnumerable<KeyValuePair<string, Func<string, Task>>> eventHandlers)
    {
        _handler = handler;
        _consumerConfig = consumerConfig;
        _eventHandlers = new ConcurrentDictionary<string, Func<string, Task>>(eventHandlers);
    }

    public async Task StartConsumingAsync(CancellationToken cancellationToken)
    {
        using var consumer = new ConsumerBuilder<string, string>(_consumerConfig.ConsumerConfig).Build();
        consumer.Subscribe(_consumerConfig.Topics);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken);

                if (_eventHandlers.TryGetValue(consumeResult.Topic, out var handler))
                {
                    Console.WriteLine($"Consumed message '{consumeResult.Message.Value}' at: '{consumeResult.Topic}'");
                    await handler(consumeResult.Message.Value);
                }
                else
                {
                    Console.WriteLine($"No handler found for topic: {consumeResult.Topic}");
                }
            }
        }
        catch (OperationCanceledException) { }
        finally
        {
            consumer.Close();
        }
    }
}
