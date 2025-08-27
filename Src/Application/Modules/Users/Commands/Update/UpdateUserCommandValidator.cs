using Application.Common.Interfaces.Persistence;
using Application.Modules.Users.Bases.Requests.Users;
using FluentValidation;

namespace Application.Modules.Users.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
    }
}

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator(IUnitOfWork unitOfWork)
    {
        Include(new UserRequestValidator(unitOfWork));
    }
}