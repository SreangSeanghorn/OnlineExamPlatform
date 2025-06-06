using OnlineExam.UserService.Application.Shared.Commands;

namespace OnlineExam.UserService.Application.Shared.Resolver
{
    public interface ICommandResolver
    {
          Task<TResult> ResolveHandler<TCommand, TResult>(TCommand command)
           where TCommand : ICommand<TResult>;
          Task ResolveHandler<TCommand>(TCommand command)
              where TCommand : ICommand;
    }
 
}