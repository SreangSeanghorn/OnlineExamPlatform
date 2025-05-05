using FluentValidation;

namespace OnlineExam.UserService.Application.RolePermissions.AssignRolePermissions;

public class AssignPermissionToRoleValidator : AbstractValidator<AssignPermissionToRoleCommand>
{
    public AssignPermissionToRoleValidator()
    {
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("Role ID is required.");

        RuleFor(x => x.PermissionId)
            .NotEmpty()
            .WithMessage("Permission ID is required.");
    }
    
}