using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Mapping;

internal static class Startup
{
	public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
	{
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		return services;
	}
}
