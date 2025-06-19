using Application.Modules.Users.Entities;
using AutoMapper;
using Core.Bases;
using Core.Common.Enums;

namespace Application.Modules.Users.Responses.Users;

public class UserBaseResponse : BaseEntity
{
    public string Username { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Avatar { get; set; }

    public Gender Gender { get; set; } = Gender.Other;

    public DateTimeOffset? DateOfBirth { get; set; }

    public OperationStatus Status { get; set; } = OperationStatus.Active;
}

public class UserBaseMapping : Profile
{
    public UserBaseMapping()
    {
        CreateMap<User, UserBaseResponse>();
    }
}