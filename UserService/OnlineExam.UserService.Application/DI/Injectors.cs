using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.UserService.Application.AssignedRoleUser;
using OnlineExam.UserService.Application.Commons.Resolver;
using OnlineExam.UserService.Application.Permissions;
using OnlineExam.UserService.Application.RolePermissions.AssignRolePermissions;
using OnlineExam.UserService.Application.RolePermissions.RevokePermissions;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Application.Shared.Resolver;
using OnlineExam.UserService.Application.Shared.Responses;
using OnlineExam.UserService.Application.UserLogin;
using OnlineExam.UserService.Application.UserRefreshToken;
using OnlineExam.UserService.Application.UserRegistered;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Roles;
using OnlineExam.UserService.Infrastructure.Users;

namespace OnlineExam.UserService.Application.DI
{
    public static class Injectors
    {
        public static IServiceCollection AddApplication(this IServiceCollection services){
            services.AddScoped<ICommandResolver, CommandResolver>();
            services.AddScoped<IQueryResolver, QueryResolver>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepositoy>();
            services.AddScoped<ICommandHandler<UserRegisterCommand, BaseResponse<UserRegisteredResponse>>, UserRegisterCommandHandler>();
            services.AddScoped<IValidator<UserRegisterCommand>, UserRegisterValidator>();
            services.AddScoped<UserRegisteredService>();
            services.AddScoped<ICommandHandler<UserLoginCommand, BaseResponse<UserLoginResponse>>, UserLoginCommandHandler>();
            services.AddScoped<UserLoginService>();
            services.AddScoped<ICommandHandler<UserRefreshTokenCommand, BaseResponse<UserRefreshTokenResponse>>, UserRefreshTokenCommandHandler>();
            services.AddScoped<UserRefreshTokenService>();
            services.AddScoped<ICommandHandler<AssignedRoleUserCommand>, AssignRoleCommandHandler>();
            services.AddScoped<IValidator<AssignedRoleUserCommand>, AssignedRoleUserValidator>();
            services.AddScoped<ICommandHandler<AddPermissionCommand>, AddPermissionHandler>();
            services.AddScoped<IValidator<AddPermissionCommand>, AddPermissionValidator>();
            services.AddScoped<ICommandHandler<AssignPermissionToRoleCommand>, AssignPermissionToRoleHandler>();
            services.AddScoped<IValidator<AssignPermissionToRoleCommand>, AssignPermissionToRoleValidator>();
            services
                .AddScoped<ICommandHandler<RevokePermissionFromRoleCommand>, RevokePermissionFromRoleCommandHandler>();
            services.AddScoped<IValidator<RevokePermissionFromRoleCommand>, RevokePermissionFromRoleCommandValidator>();
            return services;

        }
    }
}