using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.EndTurn;

public class EndTurnCommandHandler : IRequestHandler<EndTurnCommand, ApiResponse<SessionEncounterData>>
{
    private readonly ISessionRpcClient _client;
    public EndTurnCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionEncounterData>> Handle(EndTurnCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.EndTurn(request, request.Token!);
        return result.ToApiResponse(x => x, "Error ending the turn");
    }
}
