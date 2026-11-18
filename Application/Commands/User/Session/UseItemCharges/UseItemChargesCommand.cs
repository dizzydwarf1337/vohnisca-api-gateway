using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UseItemCharges;

// I-08: a magic item's charges spent at the table — its activation paid in a fight (the Magic action, or the
// property's own); what the property does is the GM's to play. Use: the property named (its cost).
public class UseItemChargesCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid InstanceId { get; set; }
    public int Count { get; set; } = 1;
    public string? Use { get; set; }
}
