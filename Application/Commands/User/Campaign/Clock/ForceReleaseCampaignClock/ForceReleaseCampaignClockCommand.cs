using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Clock.ForceReleaseCampaignClock;

// The GM takes the clock back from a session that fell without closing.
public class ForceReleaseCampaignClockCommand : UserRequest<CampaignClockData>
{
    public Guid CampaignId { get; set; }
}
