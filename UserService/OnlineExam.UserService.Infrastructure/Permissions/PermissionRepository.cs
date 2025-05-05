using Microsoft.EntityFrameworkCore;
using OnlineExam.UserService.Domain.Permissions;
using OnlineExam.UserService.Infrastructure.Commons;
using OnlineExam.UserService.Infrastructure.Persistences.DBContext;

namespace OnlineExam.UserService.Infrastructure.Permissions;

public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    public PermissionRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Permission> GetPermissionByNameAsync(string name)
    {
        return await _context.Set<Permission>().FirstOrDefaultAsync(p => p.Name == name);
    }
}