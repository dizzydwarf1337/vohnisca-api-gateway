using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.RemoveShopGood;

public class RemoveShopGoodCommandHandler : IRequestHandler<RemoveShopGoodCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public RemoveShopGoodCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(RemoveShopGoodCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.RemoveShopGood(request.GoodId, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error removing shop good");
    }
}