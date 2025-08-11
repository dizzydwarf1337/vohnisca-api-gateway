using vohnisca_api_gateway.Core.Extensions.Cors;
using vohnisca_api_gateway.Core.Extensions.Middleware;
using vohnisca_api_gateway.Core.ServicesConfiguration.grpcClient;
using vohnisca_api_gateway.Core.ServicesConfiguration.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppServices()
    .AddGrpcClients(builder.Configuration)
    .AddCorsPolicy()
    .AddCoreServices()
    .AddApplicationServices();

var app = builder.Build();


app.UseRouting();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
