using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Stash.GiveCoins;

public class GiveCoinsCommandHandler : IRequestHandler<GiveCoinsCommand, ApiResponse<StashData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GiveCoinsCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<StashData>> Handle(GiveCoinsCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GiveStashCoinsToCharacter(
            request.CardId, request.CharacterId, request.Coins, request.Token);
        return result.ToApiResponse(x => x.Stash, "Error giving stash coins");
    }
}