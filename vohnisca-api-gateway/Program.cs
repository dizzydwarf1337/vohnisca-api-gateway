using vohnisca_api_gateway.Core.Extensions.Cors;
using vohnisca_api_gateway.Core.Extensions.Middleware;
using vohnisca_api_gateway.Core.ServicesConfiguration.Infrastructure;
using vohnisca_api_gateway.Core.ServicesConfiguration.Proxy;
using vohnisca_api_gateway.Core.ServicesConfiguration.rpcClient;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services
    .AddAppServices()
    .AddHttpRpcClients()
    .AddCorsPolicy()
    .AddCoreServices()
    .AddApplicationServices()
    .AddHubProxy(builder.Configuration);

var app = builder.Build();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();
app.MapReverseProxy();

app.Run();
