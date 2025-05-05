using FluentValidation;
using OnlineExam.UserService.Application.Permissions;
using OnlineExam.UserService.Application.Roles;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Domain;
using OnlineExam.UserService.Domain.Permissions;
using OnlineExam.UserService.Domain.Roles;

namespace OnlineExam.UserService.Application.RolePermissions.AssignRolePermissions;

public class AssignPermissionToRoleHandler : ICommandHandler<AssignPermissionToRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<AssignPermissionToRoleCommand> _validator;
    
    public AssignPermissionToRoleHandler(
        IRoleRepository roleRepository,
        IPermissionRepository permissionRepository,
        IUnitOfWork unitOfWork,
        IValidator<AssignPermissionToRoleCommand> validator)
    {
        _roleRepository = roleRepository;
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    public async Task Handle(AssignPermissionToRoleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var role = await _roleRepository.GetByIdAsync(request.RoleId);
        if (role == null)
        {
            throw new RoleNotFoundException("Role not found");
        }
        var permission = await _permissionRepository.GetByIdAsync(request.PermissionId);
        if (permission == null)
        {
            throw new PermissionNotExistException(request.PermissionId);
        }
        role.AssignPermission(permission.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}