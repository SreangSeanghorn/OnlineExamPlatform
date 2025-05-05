namespace OnlineExam.UserService.Application.Permissions;

public record AddPermissionRequestDto(
    string Name,
    string Description);