using Application.Common.Helpers;
using Application.Common.Interfaces.Persistence;
using Infrastructure.Persistence.Configurations;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

internal static class Startup
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddOptions<DatabaseSettings>()
			.Bind(configuration.GetSection(nameof(DatabaseSettings)))
			.ValidateDataAnnotations();

		string dbProvider = "PostgreSql";
		services.AddDbContextPool<ApplicationDbContext>((serviceProvider, options) =>
		{
			var sqlSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value.SqlSettings;
			string defaultConnection = sqlSettings.ConnectionStrings.DefaultConnection;
			dbProvider = sqlSettings.Provider;
			options.UseNpgsql(
				defaultConnection,
				optionBuilder => optionBuilder.MigrationsAssembly($"Migrators.{sqlSettings.Provider}")
			);
		});

		ConsoleHelper.WriteLine("Database", $"Connected to database: {dbProvider}");

		services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}
}
