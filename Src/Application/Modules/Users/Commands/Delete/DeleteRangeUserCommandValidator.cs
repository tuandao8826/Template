using Application.Common.Interfaces.Persistence;
using Application.Common.Requests;
using Application.Modules.Users.Bases.Requests.Users;
using Application.Modules.Users.Entities;
using FluentValidation;

namespace Application.Modules.Users.Commands.Delete;

public class DeleteRangeUserCommandValidator : AbstractValidator<DeleteRangeUserCommand>
{
    public DeleteRangeUserCommandValidator(IUnitOfWork unitOfWork)
    {
        Include(new MultipleIdentiferValidator<User, Guid>(unitOfWork));
    }
}
