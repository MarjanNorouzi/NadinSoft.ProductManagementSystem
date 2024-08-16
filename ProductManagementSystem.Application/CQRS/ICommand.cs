namespace ProductManagementSystem.Application.CQRS;

public interface ICommand : IRequest<Unit>
{
}

public interface ICommand<out TResult> : IRequest<TResult>
{
}
