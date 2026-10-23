using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.TimeCondition;

// A condition on a creature ends after Seconds (null: it lasts until it's taken off). Condition: camelCase name.
public class TimeConditionCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public string Condition { get; set; } = string.Empty;
    public double? Seconds { get; set; }
}
