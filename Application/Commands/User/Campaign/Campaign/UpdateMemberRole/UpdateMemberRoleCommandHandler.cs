using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.UpdateMemberRole;

public class UpdateMemberRoleCommandHandler : IRequestHandler<UpdateMemberRoleCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public UpdateMemberRoleCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(UpdateMemberRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.UpdateMemberRole(request.CampaignId, request.TargetUserId, request.Role, request.Token!);
        return result.ToApiResponse(_ => Unit.Value, "Error updating member role");
    }
}