using Application.Modules.Users.Commands.Create;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.MediatR;

public static class Startup
{
    public static IServiceCollection AddMediatRSetup(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });

        return services;
    }
}
