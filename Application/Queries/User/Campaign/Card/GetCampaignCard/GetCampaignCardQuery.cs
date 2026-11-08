using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Card.GetCampaignCard;

public class GetCampaignCardQuery : UserRequest<CampaignCardData>
{
    public Guid CardId { get; set; }
}