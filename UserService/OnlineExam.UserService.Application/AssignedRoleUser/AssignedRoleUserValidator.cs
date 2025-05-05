using FluentValidation;

namespace OnlineExam.UserService.Application.AssignedRoleUser;

public class AssignedRoleUserValidator : AbstractValidator<AssignedRoleUserCommand>
{
    public AssignedRoleUserValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.RoleName).NotEmpty().WithMessage("RoleName is required");
    }
}