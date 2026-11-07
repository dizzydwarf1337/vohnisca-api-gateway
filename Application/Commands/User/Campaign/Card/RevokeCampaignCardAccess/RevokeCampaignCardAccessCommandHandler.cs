using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Card.RevokeCampaignCardAccess;

public class RevokeCampaignCardAccessCommandHandler : IRequestHandler<RevokeCampaignCardAccessCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public RevokeCampaignCardAccessCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(RevokeCampaignCardAccessCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.RevokeCampaignCardAccess(request.CardId, request.TargetUserId, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error revoking campaign card access");
    }
}