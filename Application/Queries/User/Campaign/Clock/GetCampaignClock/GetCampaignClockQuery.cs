using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Campaign.Clock.GetCampaignClock;

// The campaign's game time and which session, if any, holds it (I-03).
public class GetCampaignClockQuery : UserRequest<CampaignClockData>
{
    public Guid CampaignId { get; set; }
}
