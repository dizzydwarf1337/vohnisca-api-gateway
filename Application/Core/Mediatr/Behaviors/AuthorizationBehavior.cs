using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.Behavior;
using MediatR;

namespace Application.Core.Mediatr.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ICurrentUserService _currentUserService;

    public AuthorizationBehavior(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is not IUserRequest userRequest)
            return await next(cancellationToken);

        var token = _currentUserService.Token;
        if (string.IsNullOrEmpty(token))
            return Unauthorized();

        userRequest.Token = token;
        userRequest.UserId = _currentUserService.UserId;
        userRequest.IdempotencyKey = _currentUserService.IdempotencyKey;

        return await next(cancellationToken);
    }

    // The failure in the request's own ApiResponse<T> (a cast from ApiResponse<object> fits
    // only a request that answers with exactly that, and every other one ended as a 500).
    private static readonly Func<TResponse>? Refuse = typeof(TResponse) is { IsGenericType: true } type
        && type.GetGenericTypeDefinition() == typeof(ApiResponse<>)
        ? () => (TResponse)type.GetMethod(nameof(ApiResponse<object>.Failure))!.Invoke(null, ["Unauthorized", 401])!
        : null;

    private static TResponse Unauthorized()
        => Refuse is not null ? Refuse() : throw new UnauthorizedAccessException("Unauthorized");
}
