using Application.Core.ApiResponse;
using Application.Core.Validation;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Stash.SetTreasury;

public class SetTreasuryCommandHandler : IRequestHandler<SetTreasuryCommand, ApiResponse<StashData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetTreasuryCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<StashData>> Handle(SetTreasuryCommand request, CancellationToken cancellationToken)
    {
        var result = request.Operation == StashTreasuryOperations.Spend
            ? await _campaignRpcClient.SpendStashCoins(request.CardId, request.Coins, request.Token)
            : await _campaignRpcClient.AddStashCoins(request.CardId, request.Coins, request.Token);

        return result.ToApiResponse(x => x.Stash, "Error updating stash treasury");
    }
}