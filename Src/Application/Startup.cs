using Application.Common.Interfaces.DependencyInjection;
using Application.Common.Mapping;
using Application.Common.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services
			.AddApplicationCommon()
			.AddApplicationModule();
		
		return services;
	}

	private static IServiceCollection AddApplicationCommon(this IServiceCollection services)
	{
		return services
			.AddAutoRegisteredServices()
			.AddMappingProfiles()
			.AddFluentValidation();
	}

	private static IServiceCollection AddApplicationModule(this IServiceCollection services)
	{
		return services;
	}
}
