using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Stash.GetStash;

public class GetStashQueryHandler : IRequestHandler<GetStashQuery, ApiResponse<StashData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetStashQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<StashData>> Handle(GetStashQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetStash(request.CardId, request.Token);
        return result.ToApiResponse(x => x.Stash, "Error getting stash");
    }
}