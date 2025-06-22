using Application.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Modules.Roles.Entities;

public class Permission(string code, string name)
{
	public string Code { get; set; } = code;

	public string Name { get; set; } = name!;

	public string? Description { get; set; }

	public ICollection<RolePermission>? RolePermissions { get; set; }
}

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
	public void Configure(EntityTypeBuilder<Permission> builder)
	{
		builder.UseDefaultTableNaming();

		builder.HasKey(x => x.Code);

		builder.HasCitextUnique(x => x.Code);
	}
}