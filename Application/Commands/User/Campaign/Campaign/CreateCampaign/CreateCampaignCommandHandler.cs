using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Campaign.CreateCampaign;

public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, ApiResponse<CampaignData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateCampaignCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignData>> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateCampaign(request.Title, request.Description, request.UserId!.Value.ToString());
        return result.ToApiResponse(x => x.Campaign, "Error creating campaign");
    }
}