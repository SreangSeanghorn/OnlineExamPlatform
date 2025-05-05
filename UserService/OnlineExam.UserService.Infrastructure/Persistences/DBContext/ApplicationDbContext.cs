using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Infrastructure.Persistence.Configuration;
using OnlineExam.UserService.Domain;
using OnlineExam.UserService.Domain.Core.Event;
using OnlineExam.UserService.Domain.Core.Primitive;
using OnlineExam.UserService.Domain.Permissions;
using OnlineExam.UserService.Domain.RolePermissions;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;
using OnlineExam.UserService.Infrastructure.Persistences.Configuration;

namespace OnlineExam.UserService.Infrastructure.Persistences.DBContext;
    public class ApplicationDbContext : DbContext,IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        private readonly IEventPublisher _publisher;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IEventPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker
            .Entries<AggregateRoot<Guid>>()
            .Select(e => e.Entity)
            .Where(e => e.GetDomainEvents().Any())
            .SelectMany(e =>
            {
                var domainEvents = e.GetDomainEvents();

              //  e.ClearEvents();

                return domainEvents;
            })
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);

        }

        return result;
    }

    
}
   
