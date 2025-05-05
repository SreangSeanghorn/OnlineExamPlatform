using FluentValidation;

namespace OnlineExam.UserService.Application.RolePermissions.RevokePermissions;

public class RevokePermissionFromRoleCommandValidator : AbstractValidator<RevokePermissionFromRoleCommand>
{
    
    public RevokePermissionFromRoleCommandValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("Role ID is required.");

        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .WithMessage("Permission ID is required.");
    }
}