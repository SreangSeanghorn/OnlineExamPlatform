namespace NotificationService.Domain.UserRegistered

{
    public record UserRegisteredEventData<T>(
        DateTime OccurredOn,
        Guid EntityId,
        T Content
    )
    {   
    }
}
