using Application.Modules.Users.Entities;
using AutoMapper;

namespace Application.Modules.Users.Requests.Users;

public class UpdateUserRequest : UserRequest
{
}

public class UpdateUserMapping : Profile
{
    public UpdateUserMapping()
    {
        CreateMap<UpdateUserRequest, User>();
    }
}
