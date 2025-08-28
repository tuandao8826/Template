using Application.Modules.Roles.Bases.Responses.Permissions;
using Application.Modules.Roles.Entities;
using AutoMapper;

namespace Application.Modules.Roles.Bases.Responses.Roles;

public class RoleDetailResponse : RoleBaseResponse
{
    public ICollection<PermissionBaseResponse>? Permissions { get; set; }
}

public class RoleDetailMapping : Profile
{
    public RoleDetailMapping()
    {
        CreateMap<Role, RoleDetailResponse>()
            .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.RolePermissions!.Select(x => x.Permission)));
    }
}
