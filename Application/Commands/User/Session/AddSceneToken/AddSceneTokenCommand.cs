using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.AddSceneToken;

// The GM places a token on the map.
public class AddSceneTokenCommand : UserRequest<SessionSceneData>
{
    public Guid SessionId { get; set; }
    // "npc" | "item" | "marker" (characters come with their players).
    public string Kind { get; set; } = string.Empty;
    public Guid? RefId { get; set; }
    public string? Name { get; set; }
    public int Col { get; set; }
    public int Row { get; set; }
    public int Size { get; set; } = 1;
    public int Quantity { get; set; } = 1;
    public bool Hidden { get; set; }
    // An NPC's numbers, set as it is placed.
    public int? MaxHp { get; set; }
    public int? Ac { get; set; }
    public int? Speed { get; set; }
    public int? InitiativeBonus { get; set; }
    // An NPC's side: "party" (with the characters), "hostile" (default), "neutral" or a faction's name.
    public string? Team { get; set; }
    // Saving throw bonuses by ability ("dexterity": 2).
    public Dictionary<string, int>? Saves { get; set; }
}
