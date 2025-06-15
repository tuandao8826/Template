using MassTransit;

namespace Core.Bases;

public abstract class BaseEntity : BaseEntity<Guid>
{
	protected BaseEntity() => Id = NewId.Next().ToGuid();
}

public abstract class BaseEntity<TId>
{
	public TId Id { get; set; } = default!;

	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}