using Application.Common.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

internal static class Startup
{
	public static IServiceCollection AddPersistence(this IServiceCollection services)
	{
		//services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}
}
