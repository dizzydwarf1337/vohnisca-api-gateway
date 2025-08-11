using Application.Interfaces.GrpcClients;
using Infrastructure.GrpcClients;

namespace vohnisca_api_gateway.Core.ServicesConfiguration.Infrastructure;

public static class ApplicationConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthGrpcClient, AuthGrpcClient>();
        return services;
    }
}