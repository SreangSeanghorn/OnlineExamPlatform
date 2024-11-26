using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Consumers
{
    public class KafkaSettings
    {
        public string BootstrapServers { get; set; }
        public string GroupId { get; set; }
        public string[] Topics { get; set; }
        public string AutoOffsetReset { get; set; }

    
    }
}