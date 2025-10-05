using Application.Core.ApiResponse;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Core.Mediatr.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;

    public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception in pipeline");

            var response = CreateErrorResponse(ex);
            return response ?? throw new InvalidOperationException("Failed to create error response", ex);
        }
    }

    private TResponse? CreateErrorResponse(Exception ex)
    {
        if (!typeof(TResponse).IsGenericType ||
            typeof(TResponse).GetGenericTypeDefinition() != typeof(ApiResponse<>))
            return default;

        dynamic response = Activator.CreateInstance(typeof(TResponse))!;

        response.IsSuccess = false;
        response.StatusCode = ex switch
        {
            _ => 400
        };

        response.Error = ex.Message;

        return (TResponse)response;
    }
}