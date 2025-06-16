using Core.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Common.Extensions;

public static class ConfigurationExtension
{
	public static EntityTypeBuilder<T> UseDefaultTableNaming<T>(this EntityTypeBuilder<T> builder) where T : class
		=> builder.ToTable(typeof(T).Name);

	public static EntityTypeBuilder<T> HasBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
	{
		builder.HasKey(x => x.Id);
		return builder;
	}
}
