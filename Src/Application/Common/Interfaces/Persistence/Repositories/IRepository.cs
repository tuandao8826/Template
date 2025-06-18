using System.Linq.Expressions;

namespace Application.Common.Interfaces.Persistence.Repositories;

public interface IRepository<T> where T : class
{
	#region Queryable
	IQueryable<T> Find(Expression<Func<T, bool>>? predicate = null);
	#endregion

	#region GetById
	T? GetById(Guid id);

	Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

	Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default);
	#endregion

	#region Count
	int Count(Expression<Func<T, bool>>? predicate = null);

	Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
	#endregion

	#region Any
	bool Any(Expression<Func<T, bool>>? predicate = null);

	Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
	#endregion

	#region Add
	Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

	Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
	#endregion

	#region Update
	Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

	Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
	#endregion

	#region Delete
	Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

	Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
	#endregion
}