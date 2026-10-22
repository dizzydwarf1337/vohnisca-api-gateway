using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetEncounter;

public class GetEncounterQueryHandler : IRequestHandler<GetEncounterQuery, ApiResponse<SessionEncounterData>>
{
    private readonly ISessionRpcClient _client;
    public GetEncounterQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<SessionEncounterData>> Handle(GetEncounterQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetEncounter(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the fight");
    }
}
