using MassTransit;
using System.Security.Cryptography;

namespace Core.Bases;

public abstract class BaseEntity : BaseEntity<Guid>, IGuidIdentify
{
	protected BaseEntity() => Id = NewId.Next().ToGuid();
}

public abstract class BaseEntity<TId>
{
	public TId Id { get; set; } = default!;

	public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

public interface IIdentify<TId>
{
	public TId Id { get; set; }
}

public interface IGuidIdentify : IIdentify<Guid>
{

}