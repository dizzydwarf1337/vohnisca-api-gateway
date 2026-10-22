using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.SetSpent;

// Marks an action, bonus action or reaction spent (or not).
public class SetSpentCommand : UserRequest<SessionEncounterData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    // "action" | "bonusAction" | "reaction".
    public string Spend { get; set; } = string.Empty;
    public bool Used { get; set; }
}
