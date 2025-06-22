using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.LazyLoading;

public class LazyFactory<TInterface>(IServiceProvider provider) : Lazy<TInterface>(provider.GetRequiredService<TInterface>) where TInterface : class
{
}
