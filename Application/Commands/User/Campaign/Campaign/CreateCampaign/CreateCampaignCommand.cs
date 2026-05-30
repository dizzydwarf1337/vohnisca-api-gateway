using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Campaign.CreateCampaign;

public class CreateCampaignCommand : UserRequest<CampaignData>
{
    public string Title { get; set; }
    public string Description { get; set; }
}