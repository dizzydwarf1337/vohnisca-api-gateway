using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Scene.RevealSceneCard;

public class RevealSceneCardCommandHandler : IRequestHandler<RevealSceneCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public RevealSceneCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(RevealSceneCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetSceneRevealed(request.CardId, request.IsPublic, request.Token);
        return result.ToApiResponse(x => x.Card, "Error revealing scene card");
    }
}