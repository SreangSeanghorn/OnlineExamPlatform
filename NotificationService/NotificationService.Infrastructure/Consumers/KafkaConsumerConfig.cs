
using System.Runtime.CompilerServices;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace NotificationService.Infrastructure.Consumers
{
  using Confluent.Kafka;
  using Microsoft.Extensions.Options;

  public class KafkaConsumerConfig
  {
    public ConsumerConfig ConsumerConfig { get; }
    public string[] Topics { get; }

    public KafkaConsumerConfig(IOptions<KafkaSettings> kafkaSettings)
    {
      var settings = kafkaSettings.Value;

      ConsumerConfig = new ConsumerConfig
      {
        BootstrapServers = settings.BootstrapServers,
        GroupId = settings.GroupId,
        AutoOffsetReset = Enum.TryParse<AutoOffsetReset>(settings.AutoOffsetReset, out var offsetReset)
              ? offsetReset
              : AutoOffsetReset.Earliest
      };

      Topics = settings.Topics;
    }
  }



}