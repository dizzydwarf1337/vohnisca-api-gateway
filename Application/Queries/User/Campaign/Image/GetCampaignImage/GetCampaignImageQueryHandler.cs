using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Image.GetCampaignImage;

public class GetCampaignImageQueryHandler : IRequestHandler<GetCampaignImageQuery, ApiResponse<CampaignImageContentData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetCampaignImageQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignImageContentData>> Handle(GetCampaignImageQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetCampaignImage(request.ImageId, request.Token);

        return result.ToApiResponse(x => x.Image, "Error getting the image");
    }
}
