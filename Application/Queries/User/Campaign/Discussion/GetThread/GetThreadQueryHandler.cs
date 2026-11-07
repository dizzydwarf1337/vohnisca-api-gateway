using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Discussion.GetThread;

public class GetThreadQueryHandler : IRequestHandler<GetThreadQuery, ApiResponse<ThreadViewResponse>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetThreadQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ThreadViewResponse>> Handle(GetThreadQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetThread(request.ThreadId, request.Page, request.PageSize, request.Token);
        return result.ToApiResponse(x => x, "Error getting thread");
    }
}