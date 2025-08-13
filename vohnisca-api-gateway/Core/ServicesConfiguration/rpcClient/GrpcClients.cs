using EdjCase.JsonRpc.Client;

namespace vohnisca_api_gateway.Core.ServicesConfiguration.rpcClient
{
    public static class HttpRpcClients
    {
        public static IServiceCollection AddHttpRpcClients(this IServiceCollection services, IConfiguration configuration)
        {
            var authServiceUri = new Uri(configuration["RpcServices:AuthService"] ?? "");
            
            services.AddSingleton(sp =>
            {
                var httpClient = new HttpRpcClientBuilder(authServiceUri)
                    .ConfigureHttp(opt =>
                    {
                        opt.Headers = [("Accept", "application/json")];
                    })
                    .Build();
                return httpClient;
            });

            return services;
        }
    }
}