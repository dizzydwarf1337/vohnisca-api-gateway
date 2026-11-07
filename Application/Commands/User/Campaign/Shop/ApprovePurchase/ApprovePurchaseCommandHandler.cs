using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.ApprovePurchase;

public class ApprovePurchaseCommandHandler : IRequestHandler<ApprovePurchaseCommand, ApiResponse<ShopPurchaseData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ApprovePurchaseCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<ShopPurchaseData>> Handle(ApprovePurchaseCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ApprovePurchase(request.PurchaseId, request.Token);
        return result.ToApiResponse(x => x.ShopPurchase, "Error approving purchase");
    }
}