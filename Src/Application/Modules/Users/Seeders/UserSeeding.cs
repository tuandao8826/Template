using Application.Common.Definitions.AclPermissions;
using Application.Common.Definitions.Constants;
using Application.Common.Extensions;
using Application.Common.Helpers;
using Application.Common.Interfaces.Persistence;
using Application.Common.Seeders;
using Application.Modules.Roles.Entities;
using Application.Modules.Users.Entities;
using AutoMapper;
using Core.Bases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.Users.Seeders;

public class UserSeeding(IUnitOfWork unitOfWork, IMapper mapper) : IDataSeeder
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
	{
		ConsoleHelper.WriteLine("[Seeding][User]", "Start seeding ...");

		try
		{
			await unitOfWork.BeginTransactionAsync(cancellationToken);

			await SeedPermission(cancellationToken);
			await SeedDefaultUser(cancellationToken);

			await unitOfWork.CommitTransactionAsync(cancellationToken);
		}
		catch (Exception ex)
		{
			ConsoleHelper.WriteLine("[Seeding][User]", $"Seeding failed: {ex}");
			await unitOfWork.RollbackTransactionAsync(cancellationToken);
		}

		ConsoleHelper.WriteLine("[Seeding][User]", "Seeding success.");
	}

	private async Task SeedPermission(CancellationToken cancellationToken = default)
	{
		ConsoleHelper.WriteLine("[Seeding][User]", "Seeding permission ...");
		Guid roleId = Guid.Parse(RoleEntityConstants.Id);

		// Seeding permissions
		Permission[] permissions = mapper.Map<Permission[]>(AclPermissions.GetAll());
		Permission[] dbPermissions = await unitOfWork.Repository<Permission>().Find().AsNoTracking().ToArrayAsync(cancellationToken);

		Permission[] newPermissions = [.. permissions.ExceptBy(dbPermissions.Select(x => x.Code), x => x.Code)];
		Permission[] deletePermissions = [.. dbPermissions.ExceptBy(permissions.Select(x => x.Code), x => x.Code)];

		await unitOfWork.Repository<Permission>().AddRangeAsync(newPermissions, cancellationToken);
		await unitOfWork.Repository<Permission>().DeleteRangeAsync(deletePermissions, cancellationToken);

		// Seeding default role
		Role? role = await unitOfWork.Repository<Role>().GetByIdAsync(roleId, cancellationToken);

		if (role is null)
		{
			role = new()
			{
				Id = roleId,
				Code = RoleEntityConstants.Code,
				Name = RoleEntityConstants.Name,
				Description = RoleEntityConstants.Description,
			};

			await unitOfWork.Repository<Role>().AddAsync(role, cancellationToken);
		}

		await unitOfWork.Repository<RolePermission>().Find(x => deletePermissions.Select(x => x.Code).Contains(x.PermissionCode)).ExecuteDeleteAsync(cancellationToken);
		await unitOfWork.Repository<RolePermission>().AddRangeAsync(newPermissions.Select(x => new RolePermission { RoleId = roleId, PermissionCode = x.Code }), cancellationToken);
	}

	private async Task SeedDefaultUser(CancellationToken cancellationToken = default)
	{
		ConsoleHelper.WriteLine("[Seeding][User]", "Seeding default user ...");

		Guid userId = Guid.Parse(AdminEntityConstants.Id);
		Guid roleId = Guid.Parse(RoleEntityConstants.Id);

		User? user = await unitOfWork.Repository<User>().GetByIdAsync(userId, cancellationToken);
		
		if (user is null)
		{
			user = new User
			{
				Id = Guid.Parse(AdminEntityConstants.Id),
				Username = AdminEntityConstants.Username,
				Password = PasswordExtension.Hash(AdminEntityConstants.Password),
				Name = AdminEntityConstants.Name,
				RoleId = roleId,
			};

			await unitOfWork.Repository<User>().AddAsync(user, cancellationToken);
		}
	}
}
