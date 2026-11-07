using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Discussion.ListChapterThreads;

public class ListChapterThreadsQueryHandler : IRequestHandler<ListChapterThreadsQuery, ApiResponse<List<ThreadData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListChapterThreadsQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<ThreadData>>> Handle(ListChapterThreadsQuery request, CancellationToken cancellationToken)
    {
        var chapter = await _campaignRpcClient.GetChapter(request.ChapterId, request.Token);
        if (!chapter.IsSuccess || chapter.Data is null)
            return ApiResponse<List<ThreadData>>.Failure(chapter.Error ?? "Chapter not found", 404);

        var campaignId = Guid.TryParse(chapter.Data.Chapter.CampaignId, out var parsed) ? parsed : Guid.Empty;
        if (campaignId == Guid.Empty)
            return ApiResponse<List<ThreadData>>.Failure("Chapter has no campaign", 404);

        var result = await _campaignRpcClient.ListCampaignThreads(
            campaignId, request.ChapterId, request.Page, request.PageSize, request.Token);
        return result.ToApiResponse(x => x.Items, "Error listing chapter threads");
    }
}