using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExam.UserService.Domain.Emails;
using OnlineExam.UserService.Domain.Permissions;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Persistences.DBContext;

namespace OnlineExam.UserService.Infrastructure.DataSeeders;

public class DataSeeder : IDataSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    
    public DataSeeder(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }
    public async Task SeedAsync()
    {
        // seed permissions
        if (!await _context.Permissions.AnyAsync())
        {
            var permissions = new List<Permission>
            {
                Permission.CreatePermission("read:user", "Read user"),
                Permission.CreatePermission("write:user", "Write user"),
                Permission.CreatePermission("delete:user", "Delete user"),
                Permission.CreatePermission("read:role", "Read role"),
                Permission.CreatePermission("write:role", "Write role"),
                Permission.CreatePermission("delete:role", "Delete role")
            };

            await _context.Permissions.AddRangeAsync(permissions);
        }

        if (!await _context.Roles.AnyAsync())
        {
            var roles = new List<Role>
            {
                Role.CreateRole("Admin", "Admin role"),
                Role.CreateRole("User", "User role")
            };
            // assign all permissions to admin role
            var adminRole = roles.FirstOrDefault(r => r.Name == "Admin");
            if (adminRole != null)
            {
                var permissions = await _context.Permissions.ToListAsync();
                foreach (var permission in permissions)
                {
                    adminRole.AssignPermission(permission.Id);
                }
            }
            await _context.Roles.AddRangeAsync(roles);
        }

        if (!await _context.Users.AnyAsync())
        {
            Email email = Email.Create("admin@gmail.com");
            var password = _passwordHasher.HashPassword(null, "admin");
            var adminUser = User.Create("admin", email,password);
            // assign role to admin user
            var adminRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            if (adminRole != null)
            {
                adminUser.AssignRole(adminRole);
            }
            await _context.Users.AddAsync(adminUser);
        }
        await _context.SaveChangesAsync();
        
       
    }
}