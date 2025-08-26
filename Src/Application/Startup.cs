using Application.Common.Auths;
using Application.Common.Interfaces.DependencyInjection;
using Application.Common.LazyLoading;
using Application.Common.Mapping;
using Application.Common.MediatR;
using Application.Common.Seeders;
using Application.Common.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
	{
		services
			.AddApplicationCommon(configuration)
			.AddApplicationModule();
		
		return services;
	}

	private static IServiceCollection AddApplicationCommon(this IServiceCollection services, IConfiguration configuration)
	{
		return services
			.AddSeeders()
			.AddAuthenticationSetup(configuration)
			.AddLazyLoading()
			.AddAutoRegisteredServices()
			.AddMappingProfiles()
			.AddFluentValidation()
			.AddMediatRSetup();
	}

	private static IServiceCollection AddApplicationModule(this IServiceCollection services)
	{
		return services;
	}
}