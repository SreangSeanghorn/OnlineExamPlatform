

using ExamManagement.Application.Shared.Commands;

namespace ExamManagement.Application.Shared.Resolvers
{
    public interface ICommandResolver
    {
          Task<TResult> ResolveHandler<TCommand, TResult>(TCommand command)
           where TCommand : ICommand<TResult>;
    }
}