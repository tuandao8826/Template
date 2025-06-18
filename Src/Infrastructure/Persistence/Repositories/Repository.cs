using Application.Common.Interfaces.Persistence.Repositories;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace Infrastructure.Persistence.Repositories;

internal class Repository<T>(DbContext context) : IRepository<T> where T : class
{
	public IQueryable<T> Find(Expression<Func<T, bool>>? predicate = null)
		=> predicate is null ? context.Set<T>() : context.Set<T>().Where(predicate);

	public T? GetById(Guid id)
		=> context.Set<T>().Find(id);

	public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
		=> await context.Set<T>().FindAsync([id], cancellationToken);

	public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default)
		=> await context.Set<T>().FindAsync([id], cancellationToken);

	public int Count(Expression<Func<T, bool>>? predicate = null)
		=> predicate is null ? context.Set<T>().Count() : context.Set<T>().Count(predicate);

	public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
		=> predicate is null ? await context.Set<T>().CountAsync(cancellationToken) : await context.Set<T>().CountAsync(predicate, cancellationToken);

	public bool Any(Expression<Func<T, bool>>? predicate = null)
		=> predicate is null ? context.Set<T>().Any() : context.Set<T>().Any(predicate);

	public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default)
		=> predicate is null ? await context.Set<T>().AnyAsync(cancellationToken) : await context.Set<T>().AnyAsync(predicate, cancellationToken);

	public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
	{
		context.Set<T>().Add(entity);
		await context.SaveChangesAsync(cancellationToken);
		return entity;
	}

	public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
	{
		context.Set<T>().AddRange(entities);
		await context.SaveChangesAsync(cancellationToken);
		return entities;
	}

	public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
	{
		context.Set<T>().Update(entity);
		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
	{
		context.Set<T>().UpdateRange(entities);
		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
	{
		context.Set<T>().Remove(entity);
		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
	{
		context.Set<T>().RemoveRange(entities);
		await context.SaveChangesAsync(cancellationToken);
	}
}
