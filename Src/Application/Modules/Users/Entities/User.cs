using Application.Common.Extensions;
using Application.Modules.Roles.Entities;
using Core.Bases;
using Core.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Modules.Users.Entities;

public class User : BaseEntity
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

	public Guid? RoleId { get; set; }

	public Role? Role { get; set; }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.UseDefaultTableNaming();
	}
}
