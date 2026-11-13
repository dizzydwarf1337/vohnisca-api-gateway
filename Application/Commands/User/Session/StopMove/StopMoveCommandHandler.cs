using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.StopMove;

public class StopMoveCommandHandler : IRequestHandler<StopMoveCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public StopMoveCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(StopMoveCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.StopMove(request, request.Token!);
        return result.ToApiResponse(x => x, "Error stopping the move");
    }
}
