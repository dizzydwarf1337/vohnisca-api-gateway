using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UnequipSessionItem;

// A character takes off or puts away an item.
public class UnequipSessionItemCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    // I-06: as part of the Attack action; Hand ("main" | "off"): of a pair of one stack in both hands, the one taken out.
    public bool AsAttack { get; set; }
    public string? Hand { get; set; }
}
