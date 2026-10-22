using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.JoinSession;

public class JoinSessionCommandHandler : IRequestHandler<JoinSessionCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public JoinSessionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(JoinSessionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.JoinSession(request, request.Token!);
        return result.ToApiResponse(x => x, "Error joining the session");
    }
}
