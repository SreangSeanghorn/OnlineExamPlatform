using OnlineExam.UserService.Application.Shared.Commands;

namespace OnlineExam.UserService.Application.Permissions;

public record AddPermissionCommand(
    string Name,
    string Description) 
     : ICommand;