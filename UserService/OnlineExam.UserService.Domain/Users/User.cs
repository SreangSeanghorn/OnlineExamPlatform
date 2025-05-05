using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Domain.Entities.Users;
using OnlineExam.UserService.Domain.Core.Event;
using OnlineExam.UserService.Domain.Core.Primitive;
using OnlineExam.UserService.Domain.Emails;
using OnlineExam.UserService.Domain.RefreshTokens;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.UserRegistered;

namespace OnlineExam.UserService.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        public Guid Id { get;  set; }
        public string UserName { get;  set; }
        public Email Email { get;  set; }
        public string Password { get;  set; }
         public ICollection<Role> Roles { get;  set; } = new List<Role>();
         public ICollection<RefreshToken> RefreshTokens { get;  set; } = new List<RefreshToken>();

        public User()
        {
        }
        public User(string userName, Email email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
        public User(Guid id, string username, Email email, string password)
        {
            Id = id;
            UserName = username;
            Email = email;
            Password = password;
        }
        public static User Create(string userName, Email email, string password)
        {
            password = new PasswordHasher<User>().HashPassword(null, password);
            return new User(userName, email, password);
        }
        public static User Register(string userName, Email email, string password,Role role)
        {
            var user = Create(userName, email, password);
            var roleId = role.Id;
            user.AssignRole(role);
            var userRegisteredEventData = new UserRegisteredEventData(userName, email.Value, roleId);
            // get role to ass the role 
            var userRegisteredEvent = new UserRegisteredEvent(user.Id, userRegisteredEventData);
            user.RaiseDomainEvents(userRegisteredEvent);
            return user;
        }
        public bool VerifyPassword(string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.VerifyHashedPassword(this, Password, password) == PasswordVerificationResult.Success;
        }


        public void AssignRole(Role role)
        {
            if (!Roles.Contains(role)) Roles.Add(role);
            else return;
            var strategy = RoleStrategyFactory.GetStrategy(role);
            strategy.HandleRole(this);
            RaiseRoleAssignedEvent(role.Name);
        }
        public void RaiseRoleAssignedEvent(string role)
        {
            var roleAssignedData = new RoleAssignedData(Id, role);
            var roleAssignedEvent = new RoleAssignedEvent(Id, roleAssignedData);
            RaiseDomainEvents(roleAssignedEvent);
        }

        public List<string> GetRoles()
        {
            return Roles.Select(r => r.Name).ToList();
        }
        public bool HasRole(Role role)
        {
            return Roles.Any(r => r.Name == role.Name);
        }
        public void AddRefreshToken(RefreshToken refreshToken, DateTime expiryDate)
        {
            RefreshTokens.Add(new RefreshToken(refreshToken.Token, expiryDate));
        }

        public void RevokeRefreshToken(string token)
        {
            var refreshToken = RefreshTokens.SingleOrDefault(rt => rt.Token == token);
            if (refreshToken != null) refreshToken.Revoke();
        }
        public RefreshToken GetValidRefreshToken(string token)
        {
            return RefreshTokens.SingleOrDefault(rt => rt.Token == token && rt.IsValid());
        }

    }

   
}