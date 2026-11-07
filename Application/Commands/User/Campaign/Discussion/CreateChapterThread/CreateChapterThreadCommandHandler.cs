using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Discussion.CreateChapterThread;

public class CreateChapterThreadCommandHandler : IRequestHandler<CreateChapterThreadCommand, ApiResponse<ThreadData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateChapterThreadCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ThreadData>> Handle(CreateChapterThreadCommand request, CancellationToken cancellationToken)
    {
        var chapter = await _campaignRpcClient.GetChapter(request.ChapterId, request.Token);
        if (!chapter.IsSuccess || chapter.Data is null)
            return ApiResponse<ThreadData>.Failure(chapter.Error ?? "Chapter not found", 404);

        var campaignId = Guid.TryParse(chapter.Data.Chapter.CampaignId, out var parsed) ? parsed : Guid.Empty;
        if (campaignId == Guid.Empty)
            return ApiResponse<ThreadData>.Failure("Chapter has no campaign", 404);

        var result = await _campaignRpcClient.CreateThread(
            campaignId, request.ChapterId, request.Title, request.Visibility, request.Token);
        return result.ToApiResponse(x => x.Thread, "Error creating chapter thread");
    }
}