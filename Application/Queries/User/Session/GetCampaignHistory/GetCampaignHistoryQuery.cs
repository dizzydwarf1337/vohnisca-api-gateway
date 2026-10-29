using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetCampaignHistory;

// The campaign's sessions over, newest first, and its totals (to its members).
public class GetCampaignHistoryQuery : UserRequest<CampaignHistoryData>
{
    public Guid CampaignId { get; set; }
}
