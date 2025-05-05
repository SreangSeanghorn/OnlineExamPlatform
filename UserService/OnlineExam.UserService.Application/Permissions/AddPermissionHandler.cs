using FluentValidation;
using OnlineExam.UserService.Application.Shared.CommandHandlers;
using OnlineExam.UserService.Domain;
using OnlineExam.UserService.Domain.Permissions;

namespace OnlineExam.UserService.Application.Permissions;

public class AddPermissionHandler : ICommandHandler<AddPermissionCommand>
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<AddPermissionCommand> _validator;
    
    public AddPermissionHandler(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork, IValidator<AddPermissionCommand> validator)
    {
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    public async Task Handle(AddPermissionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var existingPermission = await _permissionRepository.GetPermissionByNameAsync(request.Name);
        if (existingPermission != null)
        {
            throw new PermissionAlreadyExistException("Permission already exists");
        }
        var permission = new Permission(request.Name, request.Description);
        await _permissionRepository.AddAsync(permission);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}