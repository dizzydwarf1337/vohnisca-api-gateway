using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Chapter.ListCampaignChapters;

public class ListCampaignChaptersQueryHandler : IRequestHandler<ListCampaignChaptersQuery, ApiResponse<List<ChapterData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListCampaignChaptersQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<ChapterData>>> Handle(ListCampaignChaptersQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListCampaignChapters(request.CampaignId, request.Token!);
        return result.ToApiResponse(x => x.Chapters, "Error listing campaign chapters");
    }
}