using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineExam.UserService.API.Middleware;
using OnlineExam.UserService.Application.DI;
using OnlineExam.UserService.Application.MessageBroker;
using OnlineExam.UserService.Application.UserRegistered;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Authentication;
using OnlineExam.UserService.Infrastructure.DataSeeders;
using OnlineExam.UserService.Infrastructure.DI;
using OnlineExam.UserService.Infrastructure.Persistences.DBContext;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers(
        options =>{
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();        
        }
    );
    var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
    var openIdConnectSettings = builder.Configuration.GetSection("OpenIdConnectSettings").Get<OpenIdConnectSettings>();
    var auth0Settings = builder.Configuration.GetSection("Auth0Settings").Get<Auth0Settings>();
    var googleSettings = builder.Configuration.GetSection("GoogleSettings").Get<GoogleSettings>();
    builder.Services.AddAuthentication(
        options =>
        {
            options.DefaultScheme = "Default";
        }
    )
        .AddJwtBearer("Auth0",
        options =>
        {
            options.Authority = $"https://{auth0Settings.Domain}/";
            options.Audience = auth0Settings.Audience;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = $"https://{auth0Settings.Domain}/",
                ValidateAudience = true,
                ValidAudience = auth0Settings.Audience,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                NameClaimType = ClaimTypes.NameIdentifier,
                
            };
        }
    ).AddJwtBearer("Jwt",
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                NameClaimType = ClaimTypes.NameIdentifier,
                RoleClaimType = ClaimTypes.Role,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            };
        })
        ;
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("ReadUser", policy =>
            policy.RequireAssertion(context =>
                context.User.HasClaim(c => 
                    (c.Type == "scope" && c.Value.Split(' ').Contains("read:user")) ||
                    (c.Type == "permissions" && c.Value.Contains("read:user"))
                )
            )
        );
        options.AddPolicy("WriteUser", policy =>
            policy.RequireAssertion(context =>
                context.User.HasClaim(c => 
                    (c.Type == "scope" && c.Value.Split(' ').Contains("write:user")) ||
                    (c.Type == "permissions" && c.Value.Contains("write:user"))
                )
            )
        );
        options.AddPolicy("JwtPolicy", policy =>
        {
            policy.AddAuthenticationSchemes("Jwt");
            policy.RequireAuthenticatedUser();
        });
        options.AddPolicy("JwtOrAuth0", policy =>
        {
            policy.AddAuthenticationSchemes("Jwt", "Auth0");
            policy.RequireAuthenticatedUser();
            policy.RequireAssertion(context =>
                context.User.HasClaim(c =>
                    (c.Type == "scope" && c.Value.Split(' ').Contains("read:user")) ||
                    (c.Type == "permissions" && c.Value.Contains("read:user"))
                )
            );
        });
    });
    
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddKafkaMassProducer(builder.Configuration);
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("OnlineExam.UserService.Infrastructure")));


    builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UserRegisterCommandHandler).GetTypeInfo().Assembly));
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        // Define the Security scheme (Bearer token)
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    });

builder.Services.AddCors(
        options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }
        );
    }
);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    await seeder.SeedAsync(); 
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();

