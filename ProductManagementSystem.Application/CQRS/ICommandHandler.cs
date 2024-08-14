namespace ProductManagementSystem.Application.CQRS;

public interface ICommandHandler<in TCommand, TResult>
    where TCommand : ICommand<TResult>
    where TResult : notnull
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
}

