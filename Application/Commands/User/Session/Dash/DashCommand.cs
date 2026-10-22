using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.Dash;

// Dash: the action buys the Speed again in movement this turn.
public class DashCommand : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
}
