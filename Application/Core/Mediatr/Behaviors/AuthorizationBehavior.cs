using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests;
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
        {
            if (ApiResponse<object>.Failure("Unauthorized", 401) is TResponse r)
                return r;
            throw new InvalidOperationException("Unauthorized but cannot create response");
        }

        userRequest.Token = token;
        userRequest.UserId = _currentUserService.UserId;

        return await next(cancellationToken);
    }
}