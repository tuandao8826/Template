using Application.Common.Interfaces.Persistence;
using Application.Common.Requests;
using Application.Modules.Users.Entities;
using FluentValidation;

namespace Application.Modules.Users.Bases.Requests.Users;

public class DeleteRangeUserRequest : MultipleIdentiferRequest<Guid>
{
}

public class DeleteRangeUserValidator : AbstractValidator<DeleteRangeUserRequest>
{
    public DeleteRangeUserValidator(IUnitOfWork unitOfWork)
    {
        Include(new MultipleIdentiferValidator<User, Guid>(unitOfWork));
    }
}
