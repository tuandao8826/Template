using Application.Common.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Api.Configurations;

public static class Startup
{
	public static WebApplicationBuilder AddConfiguration(this WebApplicationBuilder builder)
	{
		var envName = builder.Environment.EnvironmentName;
		ConsoleExtension.WriteLine("Environment", $"Current Environment: {envName}");

		builder.Configuration
			.AddJsonFile(envName, "appsettings")
			.AddJsonFile(envName, "databases");

		return builder;
	}

	private static IConfigurationBuilder AddJsonFile(this IConfigurationBuilder configuration, string envName, string fileName, bool optional = false, bool reloadOnChange = true)
	{
		const string path = "Configurations";

		return configuration
			.AddJsonFile($"{path}/{fileName}.json", optional , reloadOnChange)
			.AddJsonFile($"{path}/{fileName}.{envName}.json", true, reloadOnChange);
	}
}
