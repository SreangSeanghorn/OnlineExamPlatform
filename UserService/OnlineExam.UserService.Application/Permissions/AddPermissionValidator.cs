using FluentValidation;

namespace OnlineExam.UserService.Application.Permissions;

public class AddPermissionValidator : AbstractValidator<AddPermissionCommand>
{
    public AddPermissionValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Permission name is required.")
            .MaximumLength(100)
            .WithMessage("Permission name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Permission description is required.")
            .MaximumLength(500)
            .WithMessage("Permission description must not exceed 500 characters.");
    }
    
}