using Microsoft.AspNetCore.Mvc;
using OnlineExam.UserService.Application.RolePermissions.AssignRolePermissions;
using OnlineExam.UserService.Application.RolePermissions.RevokePermissions;
using OnlineExam.UserService.Application.Shared.Resolver;
using OnlineExam.UserService.Application.Shared.Responses;

namespace OnlineExam.UserService.Application.Roles;

[ApiController]
[Route("api/roles")]
public class RoleController : ControllerBase
{
    private readonly ICommandResolver _commandResolver;
    private readonly IQueryResolver _queryResolver;
    
    public RoleController(ICommandResolver commandResolver, IQueryResolver queryResolver)
    {
        _queryResolver = queryResolver;
        _commandResolver = commandResolver;
    }

    [HttpPost("assign-permission")]
    public async Task<IActionResult> AssignPermissionToRole([FromBody] AssignPermissionToRoleRequestDto request)
    {
        var command = new AssignPermissionToRoleCommand(request.RoleId, request.PermissionId);
        await _commandResolver.ResolveHandler<AssignPermissionToRoleCommand>(command);
        var response = new BaseResponse<string>(
            true,
            200,
            "Permission Assigned Successfully",
            null);
        return Ok(response);
    }
    [HttpPost("remove-permission")]
    public async Task<IActionResult> RemovePermissionFromRole([FromBody] AssignPermissionToRoleRequestDto request)
    {
        var command = new RevokePermissionFromRoleCommand(request.RoleId, request.PermissionId);
        await _commandResolver.ResolveHandler<RevokePermissionFromRoleCommand>(command);
        var response = new BaseResponse<string>(
            true,
            200,
            "Permission Removed Successfully",
            null);
        return Ok(response);
    }

}