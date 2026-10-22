using Yarp.ReverseProxy.Configuration;

namespace vohnisca_api_gateway.Core.ServicesConfiguration.Proxy;

// Real-time hubs are proxied as they are (SignalR negotiate + WebSocket), so the frontend
// still talks only to the gateway. /hubs/session -> the session service.
public static class HubProxy
{
    public static IServiceCollection AddHubProxy(this IServiceCollection services, IConfiguration configuration)
    {
        var sessionService = configuration["RpcServices:SessionService"] ?? throw new Exception("SessionService URI not set");

        services.AddReverseProxy().LoadFromMemory(
            [
                new RouteConfig
                {
                    RouteId = "session-hub",
                    ClusterId = "session-service",
                    CorsPolicy = "CorsPolicy",
                    Match = new RouteMatch { Path = "/hubs/session/{**rest}" },
                },
            ],
            [
                new ClusterConfig
                {
                    ClusterId = "session-service",
                    Destinations = new Dictionary<string, DestinationConfig>
                    {
                        ["session-service"] = new() { Address = sessionService },
                    },
                },
            ]);
        return services;
    }
}
