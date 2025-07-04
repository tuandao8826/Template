﻿using Application.Common.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
	IRepository<TEntity> Repository<TEntity>() where TEntity : class;

	Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

	Task CommitTransactionAsync(CancellationToken cancellationToken = default);

	Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
