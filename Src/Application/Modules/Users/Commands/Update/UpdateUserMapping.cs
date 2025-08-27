using Application.Modules.Users.Bases.Requests.Users;
using Application.Modules.Users.Entities;
using AutoMapper;

namespace Application.Modules.Users.Commands.Update;

public class UpdateUserMapping : Profile
{
    public UpdateUserMapping()
    {
        CreateMap<UpdateUserCommand, User>();
    }
}
