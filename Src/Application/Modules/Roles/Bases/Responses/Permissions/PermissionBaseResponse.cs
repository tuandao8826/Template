using Application.Common.Definitions.AclPermissions;
using Application.Modules.Roles.Entities;
using AutoMapper;

namespace Application.Modules.Roles.Bases.Responses.Permissions;

public class PermissionBaseResponse
{
    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<AclUserType>? AllowedUserTypes { get; set; }
}

public class PermissionBaseMapping : Profile
{
    public PermissionBaseMapping()
    {
        CreateMap<Permission, PermissionBaseResponse>();
    }
}