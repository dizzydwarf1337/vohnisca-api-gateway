using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.ThrowItem;

// A character throws an item at a square (a vial at the creature there, Caltrops spilled, anything else lands).
public class ThrowItemCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public int Col { get; set; }
    public int Row { get; set; }
}
