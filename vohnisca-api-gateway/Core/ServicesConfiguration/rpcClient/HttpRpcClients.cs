using Application.Interfaces.RpcClients;
using EdjCase.JsonRpc.Client;
using Infrastructure.RpcClients;

namespace vohnisca_api_gateway.Core.ServicesConfiguration.rpcClient
{
    public static class HttpRpcClients
    {
        public static IServiceCollection AddHttpRpcClients(this IServiceCollection services, IConfiguration configuration)
        {
            var authServiceUri = new Uri(configuration["RpcServices:AuthService"] ?? throw new Exception("AuthService URI not set"));
            services.AddSingleton<IAuthRpcClient>(sp =>
            {
                var rpcClient = new HttpRpcClientBuilder(authServiceUri)
                    .ConfigureHttp(opt => opt.Headers = [("Accept", "application/json")])
                    .Build();
                return new AuthRpcClient(rpcClient);
            });
            
            var mailServiceUri = new Uri(configuration["RpcServices:MailService"] ?? throw new Exception("MailService URI not set"));
            services.AddSingleton<IMailRpcClient>(sp =>
            {
                var rpcClient = new HttpRpcClientBuilder(mailServiceUri)
                    .ConfigureHttp(opt => opt.Headers = [("Accept", "application/json")])
                    .Build();
                return new MailRpcClient(rpcClient);
            });
            
            return services;
        }
    }
}