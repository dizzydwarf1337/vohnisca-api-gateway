using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Scene.SetSceneComposition;

public class SetSceneCompositionCommandHandler : IRequestHandler<SetSceneCompositionCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetSceneCompositionCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(SetSceneCompositionCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetSceneComposition(
            request.CardId, request.Npcs, request.Items, request.Token);
        return result.ToApiResponse(x => x.Card, "Error setting scene composition");
    }
}