using Application.Common.Seeders;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Common.Interfaces.DependencyInjection;

internal static class Startup
{
	public static IServiceCollection AddAutoRegisteredServices(this IServiceCollection services)
	{
		//Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		//Type[] allTypes = assemblies.SelectMany(x => x.GetTypes()).ToArray();
		//Type[] allTypeInterfaces = allTypes.Where(x => x.IsInterface).ToArray();

		//RegisterByMarker<IScopedService>(services, allTypes, allTypeInterfaces, ServiceLifetime.Scoped);
		//RegisterByMarker<ITransientService>(services, allTypes, allTypeInterfaces, ServiceLifetime.Transient);
		//RegisterByMarker<ISingletonService>(services, allTypes, allTypeInterfaces, ServiceLifetime.Singleton);

		services.Scan(scan => scan
			.FromAssemblyOf<IScopedService>()
			.AddClasses(classes => classes.AssignableTo<IScopedService>())
			.AsImplementedInterfaces()
			.WithScopedLifetime()
		);

		services.Scan(scan => scan
			.FromAssemblyOf<ITransientService>()
			.AddClasses(classes => classes.AssignableTo<ITransientService>())
			.AsImplementedInterfaces()
			.WithTransientLifetime()
		);

		services.Scan(scan => scan
			.FromAssemblyOf<ISingletonService>()
			.AddClasses(classes => classes.AssignableTo<ISingletonService>())
			.AsImplementedInterfaces()
			.WithSingletonLifetime()
		);

		return services;
	}

	private static void RegisterByMarker<TMarker>(IServiceCollection services, Type[] allTypes, Type[] allTypeInterfaces, ServiceLifetime lifetime)
	{
		Type[] interfaces = allTypeInterfaces.Where(x => typeof(TMarker).IsAssignableFrom(x) && x != typeof(TMarker)).ToArray();

		foreach (var @interface in interfaces)
		{
			Type[] implementations = allTypes.Where(x => x.IsClass && !x.IsAbstract && @interface.IsAssignableFrom(x)).ToArray();

			foreach (var implementation in implementations)
			{
				switch (lifetime)
				{
					case ServiceLifetime.Scoped:
						services.AddScoped(@interface, implementation);
						break;
					case ServiceLifetime.Singleton:
						services.AddSingleton(@interface, implementation);
						break;
					case ServiceLifetime.Transient:
						services.AddTransient(@interface, implementation);
						break;
				}
			}
		}
	}
}
