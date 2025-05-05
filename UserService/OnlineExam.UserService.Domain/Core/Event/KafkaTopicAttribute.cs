namespace OnlineExam.UserService.Domain.Core.Event;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class KafkaTopicAttribute : Attribute
{
    public string Name { get; }

    public KafkaTopicAttribute(string name)
    {
        Name = name;
    }
}