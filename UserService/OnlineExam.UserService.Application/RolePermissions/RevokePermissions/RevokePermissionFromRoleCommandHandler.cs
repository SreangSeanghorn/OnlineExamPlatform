using FluentValidation;
using OnlineExam.UserService.Application.Roles;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Domain;
using OnlineExam.UserService.Domain.Roles;

namespace OnlineExam.UserService.Application.RolePermissions.RevokePermissions;

public class RevokePermissionFromRoleCommandHandler : ICommandHandler<RevokePermissionFromRoleCommand>
{
    private readonly IRoleRepository _rolePermissionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<RevokePermissionFromRoleCommand> _validator;
    
    public RevokePermissionFromRoleCommandHandler(
        IRoleRepository rolePermissionRepository,
        IUnitOfWork unitOfWork,
        IValidator<RevokePermissionFromRoleCommand> validator)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    public async Task Handle(RevokePermissionFromRoleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var role = await _rolePermissionRepository.GetByIdAsync(request.RoleId);
        if (role == null)
        {
            throw new RoleNotFoundException("Role not found");
        }
        role.RemovePermission(request.PermissionId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        

    }
}