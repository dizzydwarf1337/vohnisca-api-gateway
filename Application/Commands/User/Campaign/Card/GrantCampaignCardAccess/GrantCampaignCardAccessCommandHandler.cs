using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.GrantCampaignCardAccess;

public class GrantCampaignCardAccessCommandHandler : IRequestHandler<GrantCampaignCardAccessCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GrantCampaignCardAccessCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(GrantCampaignCardAccessCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GrantCampaignCardAccess(request.CardId, request.TargetUserId, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error granting campaign card access");
    }
}