
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
        services.AddMassTransit(mt =>
        {

            mt.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });

            mt.AddRider(rider =>
            {

                rider.UsingKafka((context, k) =>
                {
                    k.Host(brokerAddress); 
                });
            });
        });

        services.AddMassTransitHostedService(true); 
        services.AddScoped<IEventPublisher, KafkaEventPublisher>(); 
        return services;
    }


}



