using vohnisca_api_gateway.Core.Extensions.Cors;
using vohnisca_api_gateway.Core.Extensions.Middleware;
using vohnisca_api_gateway.Core.ServicesConfiguration.Infrastructure;
using vohnisca_api_gateway.Core.ServicesConfiguration.rpcClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices()
    .AddHttpRpcClients(builder.Configuration)
    .AddCorsPolicy()
    .AddCoreServices()
    .AddApplicationServices();

var app = builder.Build();


app.UseRouting();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
