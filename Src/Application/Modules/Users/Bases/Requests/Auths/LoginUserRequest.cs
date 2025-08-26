using Application.Common.Definitions.Messages;
using Application.Modules.Users.Entities;
using FluentValidation;

namespace Application.Modules.Users.Bases.Requests.Auths;

public class LoginUserRequest
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}

public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(Message<User>.Required(x => x.Username));

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(Message<User>.Required(x => x.Password));
    }
}