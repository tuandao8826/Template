using Application.Common.Definitions.Messages;
using Application.Common.Extensions;
using Application.Common.Interfaces.Persistence;
using Application.Modules.Roles.Entities;
using Application.Modules.Users.Entities;
using AutoMapper;
using Core.Common.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Application.Modules.Users.Bases.Requests.Users;

[DisplayName(nameof(User))]
public class UserRequest
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public IFormFile? AvatarFile { get; set; }

    public Gender Gender { get; set; } = Gender.Other;

    public DateTimeOffset? DateOfBirth { get; set; }

    public OperationStatus Status { get; set; } = OperationStatus.Active;

    public Guid? RoleId { get; set; }
}

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(Message<User>.Required(x => x.Username))
            .MinimumLength(6).WithMessage(Message<User>.TooShort(x => x.Username))
            .MaximumLength(50).WithMessage(Message<User>.TooLong(x => x.Username));

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(Message<User>.Required(x => x.Password))
            .MinimumLength(6).WithMessage(Message<User>.TooShort(x => x.Password))
            .MaximumLength(50).WithMessage(Message<User>.TooLong(x => x.Password));

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(Message<User>.Required(x => x.Name))
            .MaximumLength(50).WithMessage(Message<User>.TooLong(x => x.Name));

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage(Message<User>.Invalid(x => x.Email))
            .MaximumLength(100).WithMessage(Message<User>.TooLong(x => x.Email))
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTimeOffset.UtcNow).WithMessage(Message<User>.Invalid(x => x.DateOfBirth))
            .When(x => x.DateOfBirth.HasValue);

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage(Message<User>.Invalid(x => x.Gender));

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage(Message<User>.Invalid(x => x.Status));

        RuleFor(x => x.AvatarFile)
            .MustBeImage().WithMessage(Message<UserRequest>.Invalid(x => x.AvatarFile))
            .When(x => x.AvatarFile != null);

        RuleFor(x => x.RoleId)
            .Must(roleId => !roleId.HasValue || unitOfWork.HasId<Role>(roleId.Value))
            .Empty().WithMessage(Message<User>.NotFound(x => x.RoleId));
    }
}

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserRequest, User>();
    }
}