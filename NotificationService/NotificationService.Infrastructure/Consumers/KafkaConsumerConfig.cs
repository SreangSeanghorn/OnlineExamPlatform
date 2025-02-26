
using System.Runtime.CompilerServices;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace NotificationService.Infrastructure.Consumers
{
  using Confluent.Kafka;
  using Microsoft.Extensions.Options;

  public class KafkaConsumerConfig : ConsumerConfig
  {
    public ConsumerConfig ConsumerConfig { get; }
    public string[] Topics { get; }

    public KafkaConsumerConfig(IOptions<KafkaSettings> kafkaSettings)
    {
      ConsumerConfig = new ConsumerConfig
      {
        BootstrapServers = kafkaSettings.Value.BootstrapServers,
        GroupId = kafkaSettings.Value.GroupId,
        AutoOffsetReset = kafkaSettings.Value.AutoOffsetReset
      };
      Topics = kafkaSettings.Value.Topics;
    }
  }



}