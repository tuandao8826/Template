using Application.Common.Definitions.Messages;
using Application.Modules.Users.Entities;
using FluentValidation;

namespace Application.Modules.Users.Commands.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(Message<User>.Required(x => x.Username));

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(Message<User>.Required(x => x.Password));
    }
}
