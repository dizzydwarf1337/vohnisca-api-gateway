using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Stash.ListStashes;

public class ListStashesQueryHandler : IRequestHandler<ListStashesQuery, ApiResponse<List<StashData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListStashesQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<StashData>>> Handle(ListStashesQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListStashes(request.CampaignId, request.Token);
        return result.ToApiResponse(x => x.Stashes, "Error listing stashes");
    }
}