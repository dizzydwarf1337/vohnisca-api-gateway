using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.SetItemPickable;

public class SetItemPickableCommandHandler : IRequestHandler<SetItemPickableCommand, ApiResponse<CampaignCardData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetItemPickableCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignCardData>> Handle(SetItemPickableCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetItemPickable(request.CardId, request.UserIds.ToArray(), request.Token);
        return result.ToApiResponse(x => x.Card, "Error setting item pickable");
    }
}
