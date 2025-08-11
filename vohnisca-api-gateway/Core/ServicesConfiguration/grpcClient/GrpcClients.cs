namespace vohnisca_api_gateway.Core.ServicesConfiguration.grpcClient;

public static class GrpcClients
{
    
    public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        var authServiceUrl = configuration["GrpcServices:AuthService"] ?? "";
        services.AddGrpcClient<Auth.AuthService.AuthServiceClient>(opt =>
        {
            opt.Address = new Uri(authServiceUrl);
        });
        return services;
    }
}