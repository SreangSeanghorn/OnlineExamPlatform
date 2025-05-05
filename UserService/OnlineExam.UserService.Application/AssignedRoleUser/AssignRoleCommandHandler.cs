using FluentValidation;
using OnlineExam.UserService.Application.Roles;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Application.UserLogin;
using OnlineExam.UserService.Domain;
using OnlineExam.UserService.Domain.Roles;
using OnlineExam.UserService.Domain.Users;

namespace OnlineExam.UserService.Application.AssignedRoleUser;

public class AssignRoleCommandHandler : ICommandHandler<AssignedRoleUserCommand>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private IValidator<AssignedRoleUserCommand> _Validator;
    
    public AssignRoleCommandHandler(
        IUnitOfWork unitOfWork,
        IValidator<AssignedRoleUserCommand> validator,
        IUserRepository userRepository,
        IRoleRepository roleRepository)
    {
        _unitOfWork = unitOfWork;
        _Validator = validator;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }
    public async Task Handle(AssignedRoleUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _Validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var user = await _userRepository.GetUserByIdWithRolesAsync(request.UserId);
        if (user == null)
        {
            throw new UserNotFoundException($"User with id {request.UserId} not found");
        }

        var role = await _roleRepository.GetRoleByNameAsync(request.RoleName);
        if (role == null)
        {
            throw new RoleNotFoundException($"Role with name {request.RoleName} not found");
        }
        if (user.HasRole(role))
        {
            throw new UserAlreadyHasRoleException($"User with id {request.UserId} already has role {request.RoleName}");
        }
        user.AssignRole(role);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
    }
}