
using OnlineExam.UserService.Domain.Core.Event;

namespace OnlineExam.UserService.Domain.Roles;

[KafkaTopic("role-assigned")]
public class RoleAssignedEvent : DomainEvent<RoleAssignedData>
{
    public RoleAssignedEvent(Guid entityId, RoleAssignedData content) : base(entityId, content)
    {
    }
}
