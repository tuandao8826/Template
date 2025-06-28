using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Seeders;

public static class Startup
{
	public static IServiceCollection AddSeeders(this IServiceCollection services)
	{
		services.AddSingleton<DataSeedRunner>();

		services.Scan(scan => scan
			.FromAssemblyOf<IDataSeeder>()
			.AddClasses(classes => classes.AssignableTo<IDataSeeder>())
			.AsImplementedInterfaces()
			.WithTransientLifetime()
		);

		return services;
	}

	public static async Task InitializeSeedDataAsync(this IServiceProvider service)
	{
		using var scope = service.CreateScope();
		var runner = scope.ServiceProvider.GetRequiredService<DataSeedRunner>();
		await runner.RunSeedersAsync();
	}
}
