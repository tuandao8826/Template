using StackExchange.Redis;
using System.Text.Json;

namespace Application.Common.Interfaces.Integrations.Cache;

public interface IRedisService
{
	string GetKey(string key);

	#region Set
	bool SetJson<TData>(string key, TData data, TimeSpan? expiry = null) where TData : class;

	Task<bool> SetJsonAsync<TData>(string key, TData data, TimeSpan? expiry = null) where TData : class;
	#endregion

	#region Get
	TData? GetJson<TData>(string key) where TData : class;

	Task<TData?> GetJsonAsync<TData>(string key) where TData : class;
	#endregion
}
