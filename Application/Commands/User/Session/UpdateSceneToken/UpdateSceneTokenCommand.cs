using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.UpdateSceneToken;

// The GM renames, resizes, hides or shows a token, or sets an NPC's numbers.
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
    // Saving throw bonuses by ability ("dexterity": 2); the NPC's conditions ("prone"...).
    public Dictionary<string, int>? Saves { get; set; }
    public List<string>? Conditions { get; set; }
}
