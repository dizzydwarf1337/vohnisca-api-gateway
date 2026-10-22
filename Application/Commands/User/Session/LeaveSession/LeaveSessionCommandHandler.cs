using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.LeaveSession;

public class LeaveSessionCommandHandler : IRequestHandler<LeaveSessionCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public LeaveSessionCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(LeaveSessionCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.LeaveSession(request, request.Token!);
        return result.ToApiResponse(x => x, "Error leaving the session");
    }
}
