using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.ReorderCampaignCards;

public class ReorderCampaignCardsCommandHandler : IRequestHandler<ReorderCampaignCardsCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ReorderCampaignCardsCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(ReorderCampaignCardsCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ReorderCampaignCards(request.CampaignId, request.ChapterId, request.OrderedIds, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error reordering campaign cards");
    }
}