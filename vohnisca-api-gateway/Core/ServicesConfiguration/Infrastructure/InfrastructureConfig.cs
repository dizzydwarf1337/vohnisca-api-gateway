using Application.Commands.Public.Auth.Login;
using Application.Commands.Public.Auth.SignUp;

namespace vohnisca_api_gateway.Core.ServicesConfiguration.Infrastructure;
using FluentValidation;
public static class InfrastructureConfig
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });
        services.AddScoped<AbstractValidator<LoginCommand>, LoginCommandValidator>();
        services.AddScoped<AbstractValidator<SignUpCommand>, SignUpCommandValidator>();
        return services;
    }
}