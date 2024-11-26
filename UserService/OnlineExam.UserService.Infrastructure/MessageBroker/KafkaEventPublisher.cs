using System;
using Confluent.Kafka;
using MassTransit;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineExam.UserService.Domain.Core.Event;

namespace OnlineExam.UserService.Infrastructure.MessageBroker;

public class KafkaEventPublisher : IEventPublisher
{
   
    private readonly KafkaSettings _settings;

    public KafkaEventPublisher(IOptions<KafkaSettings> options)
    {
        _settings = options.Value;
    }

    public async Task Publish<TEvent>(TEvent domainEvent) where TEvent : IDomainEvent
    {
        var config = new ProducerConfig
        {
          //  BootstrapServers = _settings.BootstrapServers
            BootstrapServers = "localhost:9092"
        };

        using var producer = new ProducerBuilder<string, string>(config).Build();

        var topic = "user-registered";
        var key = Guid.NewGuid().ToString(); // A unique key for partitioning
        var value = JsonConvert.SerializeObject(domainEvent);
        Console.WriteLine($"Publishing message to topic: {topic}" +
                          $"\n\tKey: {key}" +
                          $"\n\tValue: {value}");
        try
        {
            var deliveryResult = await producer.ProduceAsync(topic, new Message<string, string>
            {
                Key = key,
                Value = value
            });
            Console.WriteLine($"Message delivered to {deliveryResult.TopicPartitionOffset}");
        }
        catch (ProduceException<string, string> ex)
        {
            Console.WriteLine($"Error publishing message: {ex.Error.Reason}");
        }

    }
}

