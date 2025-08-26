using Application.Common.Interfaces.Persistence;
using Application.Modules.Users.Bases.Requests.Users;
using FluentValidation;

namespace Application.Modules.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator(IUnitOfWork unitOfWork)
    {
        Include(new UserRequestValidator(unitOfWork));
    }
}
