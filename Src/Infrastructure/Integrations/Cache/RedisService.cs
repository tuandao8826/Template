using Application.Common.Interfaces.Integrations.Cache;
using Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json;

namespace Infrastructure.Integrations.Cache;

internal class RedisService(IConnectionMultiplexer connection, IOptions<DatabaseSettings> databaseOptions) : IRedisService
{
	private readonly IDatabase redis = connection.GetDatabase();
	private readonly RedisSettings redisSettings = databaseOptions.Value.RedisSettings;

	public string GetKey(string key) => redisSettings.Prefix + "-" + key;

	#region Set
	public bool SetJson<TData>(string key, TData data, TimeSpan? expiry = null) where TData : class
	{
		return redis.StringSet(GetKey(key), JsonSerializer.Serialize<TData>(data), expiry);
	}

	public async Task<bool> SetJsonAsync<TData>(string key, TData data, TimeSpan? expiry = null) where TData : class
	{
		return await redis.StringSetAsync(GetKey(key), JsonSerializer.Serialize<TData>(data), expiry);
	}
	#endregion

	#region Get
	public TData? GetJson<TData>(string key) where TData : class
	{
		RedisValue value = redis.StringGet(GetKey(key));
		return value.HasValue ? JsonSerializer.Deserialize<TData>(value.ToString()) : null;
	}

	public async Task<TData?> GetJsonAsync<TData>(string key) where TData : class
	{
		RedisValue value = await redis.StringGetAsync(GetKey(key));
		return value.HasValue ? JsonSerializer.Deserialize<TData>(value.ToString()) : null;
	}
	#endregion
}
