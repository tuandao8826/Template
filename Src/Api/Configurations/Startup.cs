using Microsoft.Extensions.Options;

namespace Api.Configurations;

public static class Startup
{
	private const string Databases = "databases";

	public static WebApplicationBuilder AddConfiguration(this WebApplicationBuilder builder)
	{
		var envName = builder.Environment.EnvironmentName;

		builder.Configuration
			.AddJsonFile(envName, Databases);
		return builder;
	}

	private static IConfigurationBuilder AddJsonFile(this ConfigurationManager configuration, string envName, string fileName, bool optional = false, bool reloadOnChange = true)
	{
		const string path = "Configurations";

		return configuration
			.AddJsonFile($"{path}/{fileName}.json", optional , reloadOnChange)
			.AddJsonFile($"{path}/{fileName}.{envName}.json", true, reloadOnChange);
	}
}
