using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetDiceRolls;

public class GetDiceRollsQueryHandler : IRequestHandler<GetDiceRollsQuery, ApiResponse<DiceRollsData>>
{
    private readonly ISessionRpcClient _client;
    public GetDiceRollsQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<DiceRollsData>> Handle(GetDiceRollsQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetDiceRolls(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the rolls");
    }
}
