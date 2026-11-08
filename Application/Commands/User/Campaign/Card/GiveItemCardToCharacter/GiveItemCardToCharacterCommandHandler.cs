using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.GiveItemCardToCharacter;

public class GiveItemCardToCharacterCommandHandler : IRequestHandler<GiveItemCardToCharacterCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GiveItemCardToCharacterCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(GiveItemCardToCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GiveItemCardToCharacter(request.CardId, request.CharacterId, request.Token);
        return result.ToApiResponse(x => x.Card, "Error giving item card to character");
    }
}
