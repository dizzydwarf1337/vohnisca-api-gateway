using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.SetCampaignCardChapter;

public class SetCampaignCardChapterCommandHandler : IRequestHandler<SetCampaignCardChapterCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetCampaignCardChapterCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(SetCampaignCardChapterCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetCampaignCardChapter(request.CardId, request.ChapterId, request.Token);
        return result.ToApiResponse(x => x.Card, "Error setting campaign card chapter");
    }
}
