using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		return services
			.AddPersistence();
	}
}

