using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.RollCheck;

public class RollCheckCommandHandler : IRequestHandler<RollCheckCommand, ApiResponse<DiceRollData>>
{
    private readonly ISessionRpcClient _client;
    public RollCheckCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<DiceRollData>> Handle(RollCheckCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RollCheck(request, request.Token!);
        return result.ToApiResponse(x => x, "Error rolling the check");
    }
}
