using MediatR;

namespace Application.Modules.Users.Commands.Login;

public class LoginUserCommand : IRequest<LoginUserResponse>
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}
