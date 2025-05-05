using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;

namespace OnlineExam.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.UserName).HasColumnName("Username");
            builder.Property(e => e.UserName).IsRequired();
            builder.Property(e => e.Password).IsRequired();

            builder.OwnsOne(e => e.Email, email =>
                {
                    email.Property(e => e.Value)
                         .IsRequired()
                            .HasColumnName("Email");
            });
            builder.HasMany(e => e.Roles)
                      .WithMany(e => e.Users)
                        .UsingEntity<Dictionary<string, object>>(
                          "UserRole",
                          j => j.HasOne<Role>()
                                .WithMany()
                                .HasForeignKey("RoleId"),
                          j => j.HasOne<User>()
                                .WithMany()
                                .HasForeignKey("UserId"),
                          j =>
                          {
                              j.HasKey("UserId", "RoleId");
                          });
            
        }
    }
}