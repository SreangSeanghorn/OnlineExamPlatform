using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Domain.UserRegistered;

namespace OnlineExam.UserService.Infrastructure.MessageBroker
{
    public class KafkaSettings
    {
        public string BootstrapServers { get; set; }
        public string UserRegisteredTopic { get; set; }

        public string GetTopicForEvent(Type eventType)
        {
            if (eventType == typeof(UserRegisteredEvent))
            {
                Console.WriteLine("UserRegisteredEvent occoured");
                return UserRegisteredTopic;
            }

            throw new ArgumentException("Event type not supported", nameof(eventType));
        }

    }
}