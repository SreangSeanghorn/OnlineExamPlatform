


using ExamManagement.Application.Shared.Queries;

namespace ExamManagement.Application.Shared.Resolvers
{
    public interface IQueryResolver
    {
        Task<TResult> ResolveHandler<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}

