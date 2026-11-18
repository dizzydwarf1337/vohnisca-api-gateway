using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.ResolveItemCard;

public class ResolveItemCardCommandHandler : IRequestHandler<ResolveItemCardCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ResolveItemCardCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(ResolveItemCardCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ResolveItemCard(request.CardId, request.InstanceId, request.Token);
        return result.ToApiResponse(x => x.Card, "Error resolving item card");
    }
}
