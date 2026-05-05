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

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IUserRequest userRequest)
        {
            userRequest.Token = _currentUserService.Token ?? string.Empty;
            userRequest.UserId = _currentUserService.UserId;
        }

        return await next(cancellationToken);
    }
}