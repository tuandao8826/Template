namespace Api.Common.Logging;

public static class Startup
{
	public static WebApplicationBuilder AddLoggingSetup(this WebApplicationBuilder builder)
	{
		builder.Logging.ClearProviders();
		builder.Logging.AddConsole();
		builder.Logging.AddDebug();

		// Add console logger with custom formatter
		builder.Logging.AddSimpleConsole(options =>
		{
			options.SingleLine = false;
			options.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ";
			options.UseUtcTimestamp = false;
		});

		if (System.Diagnostics.Debugger.IsAttached)
		{
			builder.Logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Information);
		}
		else
		{
			builder.Logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);
		}

		return builder;
	}
}
