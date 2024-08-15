using ProductManagementSystem.Application.CQRS;

namespace ProductManagementSystem.Application.Users.Commands.Login;

public class LoginHandler : ICommandHandler<LoginCommand, LoginResult>
{
    public Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
