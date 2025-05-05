using Confluent.Kafka;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.UserService.Domain;
using OnlineExam.UserService.Domain.Core.Event;
using OnlineExam.UserService.Domain.Permissions;
using OnlineExam.UserService.Domain.RefreshTokens;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Authentication;
using OnlineExam.UserService.Infrastructure.Authentication.JwtRefreshTokenGenerator;
using OnlineExam.UserService.Infrastructure.Authentication.JwtTokenGenerators;
using OnlineExam.UserService.Infrastructure.DataSeeders;
using OnlineExam.UserService.Infrastructure.MessageBroker;
using OnlineExam.UserService.Infrastructure.Permissions;
using OnlineExam.UserService.Infrastructure.Persistences.DBContext;
using OnlineExam.UserService.Infrastructure.Roles;
using OnlineExam.UserService.Infrastructure.Users;


namespace OnlineExam.UserService.Infrastructure.DI;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEventPublisher, KafkaEventPublisher>();
        services.AddScoped<IRoleRepository, RoleRepositoy>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddScoped<IJwtRefreshTokenGenerator, JwtRefreshTokenGenerator>();
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IDataSeeder, DataSeeder>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        return services;
    }

}
