using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UseItem;

// A character uses an item (drinks a Potion of Healing: a bonus action).
public class UseItemCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
}
