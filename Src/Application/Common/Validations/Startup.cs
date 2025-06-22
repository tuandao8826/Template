using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Validations;

internal static class Startup
{
	public static IServiceCollection AddFluentValidation(this IServiceCollection services)
	{
		services
			.AddFluentValidationAutoValidation()
			.AddValidatorsFromAssemblyContaining(typeof(Startup));

		// If a property has multiple rules and one fails, the remaining rules are skipped.
		ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

		// If one class-level validator fails, the others won't be executed.
		ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

		return services;
	}
}
