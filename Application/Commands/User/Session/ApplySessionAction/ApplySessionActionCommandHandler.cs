using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.ApplySessionAction;

public class ApplySessionActionCommandHandler : IRequestHandler<ApplySessionActionCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public ApplySessionActionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(ApplySessionActionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ApplySessionAction(request, request.Token!);
        return result.ToApiResponse(x => x, "Error applying the action");
    }
}
