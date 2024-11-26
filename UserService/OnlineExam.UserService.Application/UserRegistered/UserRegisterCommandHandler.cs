using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Application.UserRegistered;
using OnlineExam.UserService.Application.Shared.Responses;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Domain.Roles;


namespace OnlineExam.Application.CommandHandler.Authentication
{
    public class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, BaseResponse<UserRegisteredResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRoleRepository _roleRepository;
        private readonly  UserRegisteredService _userService;
        private readonly IValidator<UserRegisterCommand> _userRegisterCommandValidator;


        public UserRegisterCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, 
        UserRegisteredService userService, IValidator<UserRegisterCommand> userRegisterCommandValidator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _userService = userService;
            _userRegisterCommandValidator = userRegisterCommandValidator;
        }

        public async Task<BaseResponse<UserRegisteredResponse>> Handle(UserRegisterCommand command, CancellationToken cancellationToken)
        {
            var valid = _userRegisterCommandValidator.Validate(command);
            if (!valid.IsValid)
            {
                throw new InvalidUserRegisterException(valid.Errors.First().ErrorMessage);
            }
            var userRegistered = await _userRepository.GetUserByEmailAsync(command.Email);
            var userRegisteredByUsername = await _userRepository.GetUserByUsernameAsync(command.UserName);
            if (userRegistered != null || userRegisteredByUsername != null)
            {
                throw new UserAlreadyExistException("User already exist in the command.");
            }
            var user = await _userService.RegisterUserAsync(command.UserName, command.Email, command.Password);         
            var userRegisteredResponse = new UserRegisteredResponse(user.UserName, user.Email.Value);
            return new BaseResponse<UserRegisteredResponse>(true,200,"",userRegisteredResponse);
               
        }

    }
}