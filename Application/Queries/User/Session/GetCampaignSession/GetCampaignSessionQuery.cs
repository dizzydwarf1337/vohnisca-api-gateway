using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetCampaignSession;

// The campaign's open session, if any.
public class GetCampaignSessionQuery : UserRequest<CampaignSessionData>
{
    public Guid CampaignId { get; set; }
}
