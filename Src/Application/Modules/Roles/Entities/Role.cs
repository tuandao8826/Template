using Application.Common.Extensions;
using Core.Bases;
using Core.Bases.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Modules.Roles.Entities;

public class Role(string code, string? name, string? description) : BaseEntity, ICode
{
	public string? Code { get; set; } = code;

	public string? Name { get; set; } = name;

	public string? Description { get; set; } = description;

	public ICollection<RolePermission>? RolePermissions { get; set; }
}

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		builder.UseDefaultTableNaming().HasBaseEntity();

		builder.HasCitextUnique(x => x.Code);
	}
}
