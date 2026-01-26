using Application.Core.Mediatr.Requests;
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
        if (request is AuthorizedRequest<TResponse> authorizedRequest)
        {
            authorizedRequest.Token = _currentUserService.Token ?? string.Empty;
            authorizedRequest.UserId = _currentUserService.UserId;
        }

        return await next(cancellationToken);
    }
}