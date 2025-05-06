using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.UserService.Application.AssignedRoleUser;
using OnlineExam.UserService.Application.Shared.Resolver;

namespace OnlineExam.UserService.Application.Users;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
   private ICommandResolver _commandResolver;
   private IQueryResolver _queryResolver;
   public UserController(ICommandResolver commandResolver, IQueryResolver queryResolver)
   {
      _commandResolver = commandResolver;
      _queryResolver = queryResolver;
   }
   
   
   [Authorize(Policy = "JwtOrAuth0")]
   [HttpPost("assign-role")]
   public async Task<IActionResult> AssignRole([FromBody] AssignedRoleUserRequestDto request)
   {
      if (request == null)
      {
         return BadRequest();
      }

      var command = new AssignedRoleUserCommand
      {
         UserId = request.UserId,
         RoleName = request.RoleName
      };

      await _commandResolver.ResolveHandler<AssignedRoleUserCommand>(command);
      return Ok(new { Message = "Role assigned successfully" });
   }
}
