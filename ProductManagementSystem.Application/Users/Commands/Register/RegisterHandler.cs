using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Users.Commands.Register;

public class RegisterHandler : ICommandHandler<RegisterCommand, RegisterResult>
{
    public Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
