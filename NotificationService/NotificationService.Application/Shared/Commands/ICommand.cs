using MediatR;

namespace NotificationService.Application.Shared.Commands
{
    public interface ICommand : IRequest
    {
        
    }
    public interface ICommand<TResult> : IRequest<TResult>
    {
        
    } 

}