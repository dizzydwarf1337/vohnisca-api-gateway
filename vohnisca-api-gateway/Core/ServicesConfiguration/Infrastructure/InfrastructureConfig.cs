using Application.Commands.Public.Auth.Login;
using Application.Core.Mediatr.Behaviors;
using Application.Interfaces.Behavior;
using Infrastructure.Core.Services;

namespace vohnisca_api_gateway.Core.ServicesConfiguration.Infrastructure;
using FluentValidation;
public static class InfrastructureConfig
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            cfg.AddOpenBehavior(typeof(ExceptionHandlingBehavior<,>));
        });
        services.AddValidatorsFromAssemblyContaining<LoginCommandValidator>();
        return services;
    }
}