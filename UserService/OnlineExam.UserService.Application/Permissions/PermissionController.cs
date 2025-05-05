using Microsoft.AspNetCore.Mvc;
using OnlineExam.UserService.Application.Shared.Resolver;
using OnlineExam.UserService.Application.Shared.Responses;

namespace OnlineExam.UserService.Application.Permissions;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly ICommandResolver _commandResolver;
    private readonly IQueryResolver _queryResolver;
    
    public PermissionController(ICommandResolver commandResolver, IQueryResolver queryResolver)
    {
        _commandResolver = commandResolver;
        _queryResolver = queryResolver;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> CreatePermission([FromBody]  AddPermissionRequestDto requestDto)
    {
        var command = new AddPermissionCommand(requestDto.Name, requestDto.Description);
        await _commandResolver.ResolveHandler<AddPermissionCommand>(command);
        var response = new BaseResponse<EmptyResult>(
            true,
            200,
            "Permission Created Successfully",
            new EmptyResult());
        return Ok(response);
    }
 
    
}