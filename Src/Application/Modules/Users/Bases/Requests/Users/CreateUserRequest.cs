using Application.Common.Interfaces.Persistence;
using Application.Modules.Users.Entities;
using AutoMapper;
using FluentValidation;

namespace Application.Modules.Users.Bases.Requests.Users;

public class CreateUserRequest : UserRequest
{
}

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator(IUnitOfWork unitOfWork)
    {
        Include(new UserRequestValidator(unitOfWork));
    }
}

public class CreateUserMapping : Profile
{
    public CreateUserMapping()
    {
        CreateMap<CreateUserRequest, User>();
    }
}