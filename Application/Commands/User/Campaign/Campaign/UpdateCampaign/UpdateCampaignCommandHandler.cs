using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.UpdateCampaign;

public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, ApiResponse<CampaignData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public UpdateCampaignCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignData>> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.UpdateCampaign(request.CampaignId, request.Title, request.Description, request.Token!, request.Status);
        return result.ToApiResponse(x => x.Campaign, "Error updating campaign");
    }
}