using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Chapter.GetChapter;

public class GetChapterQueryHandler : IRequestHandler<GetChapterQuery, ApiResponse<ChapterData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetChapterQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ChapterData>> Handle(GetChapterQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetChapter(request.ChapterId, request.UserId!.Value.ToString());
        return result.ToApiResponse(x => x.Chapter, "Error getting chapter");
    }
}