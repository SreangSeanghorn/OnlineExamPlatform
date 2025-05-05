using OnlineExam.UserService.Application.Shared.Commands;
using OnlineExam.UserService.Application.Shared.Responses;

namespace OnlineExam.UserService.Application.AssignedRoleUser;

public record AssignedRoleUserCommand : ICommand
{
    protected internal Guid UserId { get; set; }
   protected internal string RoleName { get; set; }
}