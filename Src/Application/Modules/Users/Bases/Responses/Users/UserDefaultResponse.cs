using Application.Modules.Roles.Responses.Roles;
using Application.Modules.Users.Entities;
using AutoMapper;

namespace Application.Modules.Users.Bases.Responses.Users;

public class UserDefaultResponse : UserBaseResponse
{
    public RoleBaseResponse? Role { get; set; }
}

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDefaultResponse>();
    }
}
