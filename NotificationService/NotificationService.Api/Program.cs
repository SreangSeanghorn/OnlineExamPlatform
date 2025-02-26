using Confluent.Kafka;
using NotificationService.Application.DI;
using NotificationService.Infrastructure.Consumers;
using NotificationService.Infrastructure.DI;
using NotificationService.Infrastructure.MailSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(
    builder.Configuration);
builder.Services.AddApplication();

// add Kafka Settings
builder.Services.Configure<KafkaSettings>(builder.Configuration.GetSection("Kafka"));
builder.Services.AddKafkaMassProducer(builder.Configuration);

// add signal R
builder.Services.AddSignalR();

// add Email Settings
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));



var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();