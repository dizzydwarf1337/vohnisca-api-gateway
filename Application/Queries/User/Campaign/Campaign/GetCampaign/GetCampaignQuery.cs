using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Campaign.GetCampaign;

public class GetCampaignQuery : UserRequest<CampaignData>
{
    public Guid CampaignId { get; set; }
}