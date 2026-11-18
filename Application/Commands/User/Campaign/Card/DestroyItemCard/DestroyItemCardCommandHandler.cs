using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.DestroyItemCard;

public class DestroyItemCardCommandHandler : IRequestHandler<DestroyItemCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public DestroyItemCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(DestroyItemCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.DestroyItemCard(request.CardId, request.Token);
        return result.ToApiResponse(x => x.Card, "Error destroying item");
    }
}
