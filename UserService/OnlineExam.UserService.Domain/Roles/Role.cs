using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineExam.UserService.Domain.Core.Primitive;
using OnlineExam.UserService.Domain.Users;

namespace OnlineExam.UserService.Domain.Roles
{
    public class Role : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();   
        public Role()
        {
        }
        public Role(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
         public static Role CreateRole(string name, string description)
        {
            return new Role
            {
                Name = name,
                Description = description
            };
        }
        public static Role GetRole(string name)
        {
            return new Role
            {
                Name = name,
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Role role)
            {
                return Name == role.Name;
            }
            return false;
        }

        public new int GetHashCode()
        {
            return Name.GetHashCode();
        }


    }
}