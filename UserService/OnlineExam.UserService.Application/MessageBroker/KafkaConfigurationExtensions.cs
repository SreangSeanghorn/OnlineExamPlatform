
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.UserService.Application.UserRegistered;
using OnlineExam.UserService.Domain.Core.Event;
using OnlineExam.UserService.Domain.UserRegistered;
using OnlineExam.UserService.Infrastructure.MessageBroker;

namespace OnlineExam.UserService.Application.MessageBroker;


public static class KafkaConfigurationExtensions
{
    public static IServiceCollection AddKafkaMassProducer(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<KafkaSettings>(configuration.GetSection("Kafka"));
        var brokerAddress = configuration["Kafka:BrokerAddress"];
        // var topicName = configuration["Kafka:TopicName"];

        services.AddMassTransit(mt =>
        {
            // // Register the consumer
            // mt.AddConsumer<UserRegisteredEventConsumer>(); 

            mt.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });

            mt.AddRider(rider =>
            {
                // rider.AddConsumer<UserRegisteredEventConsumer>();  

                rider.UsingKafka((context, k) =>
                {
                    k.Host(brokerAddress); // Use the configuration value for broker address

                    // Define the topic and consumer group
                    // k.TopicEndpoint<UserRegisteredEvent>(topicName, "user-register", e =>
                    // {
                    //     e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                    //     e.ConfigureConsumer<UserRegisteredEventConsumer>(context); // Configure the consumer
                    // });
                });
            });
        });

        services.AddMassTransitHostedService(true); 
        services.AddScoped<IEventPublisher, KafkaEventPublisher>(); 
        return services;
    }


}



