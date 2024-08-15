using MediatR;

namespace ProductManagementSystem.Application.CQRS;

public interface IQuery<out TResult> : IRequest<TResult>
    where TResult : notnull
{
}
