namespace vohnisca_api_gateway.Core.Extensions.Cors;

public static class CorsPolicies
{
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.SetIsOriginAllowed(origin => origin.StartsWith("http://localhost") || origin.StartsWith("https://localhost"))
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
}