using Application.Interfaces.RpcClients;
using Infrastructure.RpcClients;

namespace vohnisca_api_gateway.Core.ServicesConfiguration.Infrastructure;

public static class ApplicationConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthRpcClient, AuthRpcClient>();
        return services;
    }
}