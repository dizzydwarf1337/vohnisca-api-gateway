using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Image.GetCampaignImage;

public class GetCampaignImageQuery : UserRequest<CampaignImageContentData>
{
    public Guid ImageId { get; set; }
}
