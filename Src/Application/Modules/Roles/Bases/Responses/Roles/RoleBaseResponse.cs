using Application.Modules.Roles.Entities;
using AutoMapper;
using Core.Bases;

namespace Application.Modules.Roles.Bases.Responses.Roles;

public class RoleBaseResponse : BaseEntity
{
    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}

public class RoleBaseMapping : Profile
{
    public RoleBaseMapping()
    {
        CreateMap<Role, RoleBaseResponse>();
    }
}