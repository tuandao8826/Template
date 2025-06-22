using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Persistence.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;

namespace Infrastructure.Persistence;

internal class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
	private readonly Hashtable repositories = [];

	public IRepository<TEntity> Repository<TEntity>() where TEntity : class
	{
		string entityFullName = typeof(TEntity).FullName!;

		if (!repositories.ContainsKey(entityFullName))
		{
			repositories.Add(entityFullName, new Repository<TEntity>(context));
		}

		return (IRepository<TEntity>)repositories[entityFullName]!;
	}

	public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
		=> context.Database.BeginTransactionAsync(cancellationToken);

	public Task CommitTransactionAsync(CancellationToken cancellationToken = default)
		=> context.Database.CommitTransactionAsync(cancellationToken);

	public Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
		=> context.Database.RollbackTransactionAsync(cancellationToken);
}