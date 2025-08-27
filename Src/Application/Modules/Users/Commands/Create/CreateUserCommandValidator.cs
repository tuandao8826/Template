using Application.Common.Definitions.Messages;
using Application.Common.Interfaces.Persistence;
using Application.Modules.Users.Bases.Requests.Users;
using Application.Modules.Users.Entities;
using FluentValidation;

namespace Application.Modules.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(Message<User>.Required(x => x.Username))
            .MinimumLength(6).WithMessage(Message<User>.TooShort(x => x.Username))
            .MaximumLength(50).WithMessage(Message<User>.TooLong(x => x.Username));

        Include(new UserRequestValidator(unitOfWork));
    }
}
