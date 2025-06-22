using Application.Common.Helpers;
using Core.Bases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace Application.Common.Extensions;

public static class ConfigurationExtension
{
	public static EntityTypeBuilder<T> UseDefaultTableNaming<T>(this EntityTypeBuilder<T> builder) where T : class
		=> builder.ToTable(NamingConventionHelper.ToSnakeCase(typeof(T).Name));

	public static EntityTypeBuilder<T> HasBaseEntity<T>(this EntityTypeBuilder<T> builder) where T : BaseEntity
	{
		builder.HasKey(x => x.Id);
		return builder;
	}

	public static EntityTypeBuilder<T> HasCitextUnique<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, object?>> expression) where T : class
	{
		builder.Property(expression).HasColumnType("citext");
		builder.HasIndex(expression).IsUnique();
		return builder;
	}
}
