using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.ReadyAction;

// Ready (SRD 5.2): the action spent on a trigger and an attack, a move or another action ("attack" | "move" | "other").
public class ReadyActionCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public string Kind { get; set; } = string.Empty;
    public string Trigger { get; set; } = string.Empty;
    public string? Detail { get; set; }
}
