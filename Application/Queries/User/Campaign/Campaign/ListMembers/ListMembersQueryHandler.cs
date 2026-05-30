using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Campaign.ListMembers;

public class ListMembersQueryHandler : IRequestHandler<ListMembersQuery, ApiResponse<List<MemberData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListMembersQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<MemberData>>> Handle(ListMembersQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListMembers(request.CampaignId, request.Token);
        return result.ToApiResponse(x => x.Members, "Error listing members");
    }
}