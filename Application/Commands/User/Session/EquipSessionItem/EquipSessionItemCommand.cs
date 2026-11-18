using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.EquipSessionItem;

// A character puts on or takes up an item (in a fight: the action; armor not at all). Hand: "main" | "off" for a weapon.
public class EquipSessionItemCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public string Hand { get; set; } = "main";
    // I-06: a weapon handled as part of the Attack action (it begins one if none is under way); the service decides the cost.
    public bool AsAttack { get; set; }
}
