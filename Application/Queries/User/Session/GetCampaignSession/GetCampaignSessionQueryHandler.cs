using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Session.GetCampaignSession;

public class GetCampaignSessionQueryHandler : IRequestHandler<GetCampaignSessionQuery, ApiResponse<CampaignSessionData>>
{
    private readonly ISessionRpcClient _client;
    public GetCampaignSessionQueryHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CampaignSessionData>> Handle(GetCampaignSessionQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetCampaignSession(request, request.Token!);
        return result.ToApiResponse(x => x, "Error getting the campaign's session");
    }
}
