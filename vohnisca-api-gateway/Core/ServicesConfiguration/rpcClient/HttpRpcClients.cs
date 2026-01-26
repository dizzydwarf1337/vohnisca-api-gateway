using Application.Interfaces.RpcClients;
using Infrastructure.RpcClients;

namespace vohnisca_api_gateway.Core.ServicesConfiguration.rpcClient;
public static class HttpRpcClients
{
    public static IServiceCollection AddHttpRpcClients(this IServiceCollection services)
    {
        services.AddScoped<IAuthRpcClient, AuthRpcClient>();
        services.AddScoped<IMailRpcClient, MailRpcClient>();
        services.AddScoped<IUserRpcClient, UserRpcClient>();
        
        return services;
    }
}
