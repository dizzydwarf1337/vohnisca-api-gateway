using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetSessionReady;

public class SetSessionReadyCommandHandler : IRequestHandler<SetSessionReadyCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetSessionReadyCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetSessionReadyCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetSessionReady(request, request.Token!);
        return result.ToApiResponse(x => x, "Error updating readiness");
    }
}
