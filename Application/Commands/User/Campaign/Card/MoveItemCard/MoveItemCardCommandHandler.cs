using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.MoveItemCard;

public class MoveItemCardCommandHandler : IRequestHandler<MoveItemCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public MoveItemCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(MoveItemCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.MoveItemCard(request.CardId, request.ContainerId, request.Token);
        return result.ToApiResponse(x => x.Card, "Error moving item card");
    }
}