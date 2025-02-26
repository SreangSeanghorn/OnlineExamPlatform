using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace NotificationService.Infrastructure.Consumers
{
    public class KafkaSettings
    {
        public string? BootstrapServers { get; set; }
        public string? GroupId { get; set; }
        public string[]? Topics { get; set; }
        public AutoOffsetReset? AutoOffsetReset { get; set; }
        

    
    }
}