namespace OnlineExam.UserService.Domain.UserRegistered

{
    public record UserRegisteredEventData(
        string UserName,
        string Email,
        Guid RoleId
    )
    {   
    }
}
