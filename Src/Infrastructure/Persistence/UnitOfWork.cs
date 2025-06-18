using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Persistence.Repositories;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence;

internal class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
	public IRepository<TEntity> Repository<TEntity>() where TEntity : class
	{
		throw new NotImplementedException();
	}

	public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
		=> context.Database.BeginTransactionAsync(cancellationToken);

	public Task CommitTransactionAsync(CancellationToken cancellationToken = default)
		=> context.Database.CommitTransactionAsync(cancellationToken);

	public Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
		=> context.Database.RollbackTransactionAsync(cancellationToken);
}