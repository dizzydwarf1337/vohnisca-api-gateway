using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.RemoveMember;

public class RemoveMemberCommandHandler : IRequestHandler<RemoveMemberCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public RemoveMemberCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(RemoveMemberCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.RemoveMember(request.CampaignId, request.TargetUserId, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error removing member");
    }
}