namespace ProductManagementSystem.Application.CQRS;

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : notnull
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
}