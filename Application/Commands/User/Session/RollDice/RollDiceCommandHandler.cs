using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.RollDice;

public class RollDiceCommandHandler : IRequestHandler<RollDiceCommand, ApiResponse<DiceRollData>>
{
    private readonly ISessionRpcClient _client;
    public RollDiceCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<DiceRollData>> Handle(RollDiceCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.RollDice(request, request.Token!);
        return result.ToApiResponse(x => x, "Error rolling the dice");
    }
}
