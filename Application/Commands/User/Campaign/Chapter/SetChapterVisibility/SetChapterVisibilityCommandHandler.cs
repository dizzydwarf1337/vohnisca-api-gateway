using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.SetChapterVisibility;

public class SetChapterVisibilityCommandHandler : IRequestHandler<SetChapterVisibilityCommand, ApiResponse<ChapterData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetChapterVisibilityCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ChapterData>> Handle(SetChapterVisibilityCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetChapterVisibility(request.ChapterId, request.IsVisibleToAll, request.Token);
        return result.ToApiResponse(x => x.Chapter, "Error setting chapter visibility");
    }
}