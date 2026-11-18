using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Campaign.Clock.AdvanceCampaignClock;

// Out of a session the GM moves the campaign's time on (a journey, downtime); refused while a session holds it.
public class AdvanceCampaignClockCommand : UserRequest<CampaignClockData>
{
    public Guid CampaignId { get; set; }
    public double Seconds { get; set; }
}
