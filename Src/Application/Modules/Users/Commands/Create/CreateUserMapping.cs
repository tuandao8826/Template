using Application.Modules.Users.Entities;
using AutoMapper;

namespace Application.Modules.Users.Commands.Create;

public class CreateUserMapping : Profile
{
    public CreateUserMapping()
    {
        CreateMap<CreateUserCommand, User>();
    }
}
