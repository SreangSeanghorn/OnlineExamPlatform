

using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Domain.Events;
using NotificationService.Domain.UserRegistered;
using NotificationService.Infrastructure.Consumers;

namespace NotificationService.Infrastructure.Consumers;


public static class KafkaConfigurationExtensions
{
    public static IServiceCollection AddKafkaMassProducer(this IServiceCollection services, ConfigurationManager configuration)
    {
        var brokerAddress = configuration["Kafka:BrokerAddress"];
        var topicName = configuration["Kafka:TopicName"];

        services.AddMassTransit(mt =>
        {
            // Register the consumer
            mt.AddConsumer<UserRegisteredConsumer>(); 

            mt.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });

            mt.AddRider(rider =>
            {
                rider.AddConsumer<UserRegisteredConsumer>();  

                rider.UsingKafka((context, k) =>
                {
                    k.Host("localhost:9092"); // Use the configuration value for broker address
                    // Define the topic and consumer group
                    k.TopicEndpoint<UserRegisteredEventData<Content>>("user-registered", "user-registered", e =>
                    {
                        e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                        e.ConfigureConsumer<UserRegisteredConsumer>(context);
                        Console.WriteLine("UserRegisteredConsumer is configured with the context: " + context);
                    });
                });
            });
        });

        services.AddMassTransitHostedService(true); 
        return services;
    }


}