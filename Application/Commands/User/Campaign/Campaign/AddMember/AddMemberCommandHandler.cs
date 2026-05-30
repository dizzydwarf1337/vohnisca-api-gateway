using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.AddMember;

public class AddMemberCommandHandler : IRequestHandler<AddMemberCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public AddMemberCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(AddMemberCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.AddMember(request.CampaignId, request.TargetUserId, request.Role, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error adding member");
    }
}