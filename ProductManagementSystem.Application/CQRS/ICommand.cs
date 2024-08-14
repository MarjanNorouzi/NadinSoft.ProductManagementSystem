namespace ProductManagementSystem.Application.CQRS;

public interface ICommand : ICommand<int>
{
}

public interface ICommand<out TResult>
{
}