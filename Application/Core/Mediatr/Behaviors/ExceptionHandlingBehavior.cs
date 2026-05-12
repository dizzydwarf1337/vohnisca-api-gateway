using Application.Core.ApiResponse;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Core.Mediatr.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;

    public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger)
        => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception for {RequestType}", typeof(TRequest).Name);

            if (ApiResponse<object>.Failure("An unexpected error occurred", 500) is TResponse r)
                return r;

            throw;
        }
    }
}