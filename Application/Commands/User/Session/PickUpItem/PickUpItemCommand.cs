using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.PickUpItem;

// A character picks up an item token within 5 feet.
public class PickUpItemCommand : UserRequest<SessionData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid TokenId { get; set; }
    // I-06: a weapon picked up straight into that free hand ("main" | "off"; none: into the pack), as part of the Attack action or not.
    public string? Wield { get; set; }
    public bool AsAttack { get; set; }
}
