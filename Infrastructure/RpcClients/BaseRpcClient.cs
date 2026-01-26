using System.Net.Http.Headers;
using EdjCase.JsonRpc.Client;

namespace Infrastructure.RpcClients;

public abstract class BaseRpcClient
{
    private readonly string _baseUrl;
    
    protected BaseRpcClient(string baseUrl)
    {
        _baseUrl = baseUrl;
    }
    
    protected RpcClient CreateRpcClient(string? route = null, string? token = null)
    {
        var url = string.IsNullOrEmpty(route) 
            ? _baseUrl 
            : $"{_baseUrl.TrimEnd('/')}/{route.TrimStart('/')}";
        
        var builder = new HttpRpcClientBuilder(new Uri(url))
            .ConfigureHttp(opt =>
            {
                opt.Headers = [("Accept", "application/json")];
            });
        
        if (!string.IsNullOrEmpty(token))
        {
            builder.UsingAuthHeader(new AuthenticationHeaderValue("Bearer", token));
        }
        
        return builder.Build();
    }
}