using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Image.UploadCampaignImage;

public class UploadCampaignImageCommand : UserRequest<CampaignImageData>
{
    public Guid CampaignId { get; set; }
    public byte[] Data { get; set; }
    public string MimeType { get; set; }
}
