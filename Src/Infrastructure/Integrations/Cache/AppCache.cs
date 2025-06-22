namespace Infrastructure.Integrations.Cache;

internal static class AppCache
{
	public static Dictionary<string, object> Data = [];
}

internal static class AppCacheType
{
	public const string RedisPrefix = nameof(RedisPrefix);
}
