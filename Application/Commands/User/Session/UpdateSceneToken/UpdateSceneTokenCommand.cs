using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UpdateSceneToken;

// The GM renames, resizes, hides or shows a token.
public class UpdateSceneTokenCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public string? Name { get; set; }
    public int? Size { get; set; }
    public int? Quantity { get; set; }
    public bool? Hidden { get; set; }
    // An NPC's numbers in play.
    public int? MaxHp { get; set; }
    public int? Hp { get; set; }
    public int? Ac { get; set; }
    public int? Speed { get; set; }
    public int? InitiativeBonus { get; set; }
}
