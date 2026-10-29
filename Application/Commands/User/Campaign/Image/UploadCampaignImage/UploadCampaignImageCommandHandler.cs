using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Image.UploadCampaignImage;

public class UploadCampaignImageCommandHandler : IRequestHandler<UploadCampaignImageCommand, ApiResponse<CampaignImageData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public UploadCampaignImageCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<CampaignImageData>> Handle(UploadCampaignImageCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.UploadCampaignImage(
            request.CampaignId, request.MimeType, Convert.ToBase64String(request.Data), request.Token);

        return result.ToApiResponse(x => x.Image, "Error uploading the image");
    }
}
