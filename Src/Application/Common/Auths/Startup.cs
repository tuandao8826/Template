using Application.Common.Auths.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Auths;

internal static class Startup
{
	public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddOptions<SecuritySettings>()
			.Bind(configuration.GetSection(nameof(SecuritySettings)))
			.ValidateDataAnnotations();

		return services;
	}
}
