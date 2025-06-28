using Microsoft.Extensions.DependencyInjection;
using System;

namespace Application.Common.Seeders;

public class DataSeedRunner(IServiceProvider serviceProvider)
{
	private readonly IServiceProvider serviceProvider = serviceProvider;

	public async Task RunSeedersAsync(CancellationToken cancellationToken = default)
	{
		using var scope = serviceProvider.CreateScope();
		var seeders = scope.ServiceProvider.GetServices<IDataSeeder>();

		foreach (IDataSeeder seeder in seeders)
		{
			await seeder.SeedAsync(cancellationToken);
		}
	}
}
