

using OnlineExam.UserService.Application.Shared.Queries;

namespace OnlineExam.UserService.Application.Shared.Resolver
{
    public interface IQueryResolver
    {
        Task<TResult> ResolveHandler<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}

