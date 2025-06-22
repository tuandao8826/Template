using Application.Common.Helpers;
using Application.Common.Interfaces.Integrations.Cache;
using Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Infrastructure.Integrations.Cache;

internal static class Startup
{
	public static IServiceCollection AddRedis(this IServiceCollection services)
	{
		services.AddSingleton<IConnectionMultiplexer>(serviceProvider =>
		{
			RedisSettings redisSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value.RedisSettings;
			var multiplexer = ConnectionMultiplexer.Connect(redisSettings.ConnectionStrings.DefaultConnection);
			return multiplexer;
		});

		ConsoleHelper.WriteLine("Redis", $"Connected to redis.");

		services.AddScoped<IRedisService, RedisService>();

		return services;
	}
}
