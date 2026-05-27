using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.CreateChapter;

public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand, ApiResponse<ChapterData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateChapterCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ChapterData>> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateChapter(request.CampaignId, request.ParentId, request.Title, request.Content, request.UserId!.Value.ToString());
        return result.ToApiResponse(x => x.Chapter, "Error creating chapter");
    }
}