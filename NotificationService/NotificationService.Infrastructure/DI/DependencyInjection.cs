using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NotificationService.Application.Services;
using NotificationService.Domain.Interfaces;
using NotificationService.Infrastructure.Consumers;
using NotificationService.Infrastructure.Services;

namespace NotificationService.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            
            services.AddSingleton<KafkaConsumerConfig>();
            services.AddSingleton<UserRegisteredConsumer>();
            services.AddSingleton<INotificationHandler, NotificationHandler>();
            services.AddSingleton<IEmailSender, EmailSender>();
            return services;
        }
        
    }
}