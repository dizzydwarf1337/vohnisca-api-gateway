using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.OpenSession;

// The GM opens a game session for the campaign; its members are notified and can join.
public class OpenSessionCommand : UserRequest<SessionData>
{
    public Guid CampaignId { get; set; }
}
