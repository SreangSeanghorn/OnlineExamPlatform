
using Microsoft.AspNetCore.Identity;
using OnlineExam.UserService.Domain;
using OnlineExam.UserService.Domain.Core.Event;
using OnlineExam.UserService.Domain.Emails;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;

namespace OnlineExam.UserService.Application.UserRegistered
{
    public class UserRegisteredService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public UserRegisteredService(IUserRepository userRepository, IRoleRepository roleRepository, IEventPublisher eventPublisher, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _eventPublisher = eventPublisher;
            _unitOfWork = unitOfWork;
        }

        public Task AssignRoleToUser(Guid userId, Role role)
        {
            var user = _userRepository.GetByIdAsync(userId).Result;
            user.AssignRole(role);
            return _userRepository.SaveChangesAsync();
        }
        public Task<User> GetUserByEmailAsync(string email)
        {
            return _userRepository.GetUserByEmailAsync(email);
        }
        public async Task<User> RegisterUserAsync(string name, string email, string password)
        {
            var mail = new Email(email);
            var userRegistered = await _userRepository.GetUserByEmailAsync(email);
            if (userRegistered != null)
            {
                throw new Exception("User already registered.");
            }
            var role = _roleRepository.GetDefaultRole().Result;
            
            var user = User.Register(name, mail, password, role);
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

    }
}