using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.LazyLoading;

internal static class Startup
{
	public static IServiceCollection AddLazyLoading(this IServiceCollection services)
	{
		services.AddScoped(typeof(Lazy<>), typeof(LazyFactory<>));
		return services;
	}
}
