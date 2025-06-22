# 🐢 Lazy Dependency Injection for RedisService

This guide shows how to inject and use a lazy-loaded `Ex: IRedisService` in your .NET project.

---

## 💉 Inject `Lazy<IRedisService>` via Constructor

```csharp
public class YourService
{
    private readonly Lazy<IRedisService> _lazyRedis;

    public YourService(Lazy<IRedisService> lazyRedis)
    {
        _lazyRedis = lazyRedis;
    }
}
```

---

## 🚀 Example usage

```csharp
IRedisService redisService = _lazyRedis.Value;
await redisService.SetJsonAsync("key", new { message = "Hello" });
```