using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationService.Application.DI;
using NotificationService.Infrastructure.Consumers;
using NotificationService.Infrastructure.DI;
using NotificationService.Worker;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, builder) =>
    {
        builder.SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {

        var kafkaSection = context.Configuration.GetSection("Kafka");
        services.Configure<KafkaSettings>(kafkaSection);

    })
    .ConfigureServices((context, services) =>
    {
        services.AddInfrastructure();
        services.AddApplication();
        services.AddHostedService<NotificationWorker>();

    })
    .Build();

await host.RunAsync();
