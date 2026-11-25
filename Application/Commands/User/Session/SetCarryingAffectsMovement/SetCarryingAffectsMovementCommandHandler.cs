using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.SetCarryingAffectsMovement;

public class SetCarryingAffectsMovementCommandHandler : IRequestHandler<SetCarryingAffectsMovementCommand, ApiResponse<SessionData>>
{
    private readonly ISessionRpcClient _client;
    public SetCarryingAffectsMovementCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionData>> Handle(SetCarryingAffectsMovementCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.SetCarryingAffectsMovement(request, request.Token!);
        return result.ToApiResponse(x => x, "Error changing the session's setting");
    }
}
