using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.UpdateChapter;

public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand, ApiResponse<ChapterData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public UpdateChapterCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ChapterData>> Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.UpdateChapter(request.ChapterId, request.Title, request.Content, request.UserId!.Value.ToString());
        return result.ToApiResponse(x => x.Chapter, "Error updating chapter");
    }
}