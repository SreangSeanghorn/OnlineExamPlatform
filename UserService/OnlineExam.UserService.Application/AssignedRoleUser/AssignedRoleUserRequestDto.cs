namespace OnlineExam.UserService.Application.AssignedRoleUser;

public record AssignedRoleUserRequestDto(
    Guid UserId,
    string RoleName
    );