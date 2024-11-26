using System;
using FluentValidation;

namespace OnlineExam.UserService.Application.UserRegistered;

public class UserRegisterValidator : AbstractValidator<UserRegisterCommand>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password is required and must be at least 6 characters");
       
    }

}
