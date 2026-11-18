using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.CreateItem;

// A user's own item in the workshop service. Rarity and Visibility by name ("Rare",
// "Public"); AbilityScoreBonuses by ability name ("Strength": 2); Image is the optional
// icon from the form's file.
public class CreateWorkshopItemCommand : UserRequest<CreatedContent>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public double Weight { get; set; }
    public int ValueInCopper { get; set; }
    public string Rarity { get; set; } = "Common";
    public string Visibility { get; set; } = "Private";
    // Raw property names ("Consumable", "Glowing"), as the workshop's enum spells them.
    public List<string>? Properties { get; set; }
    public List<Guid>? GrantedSpellIds { get; set; }
    public Dictionary<string, int>? AbilityScoreBonuses { get; set; }
    public int? ArmorClassBonus { get; set; }
    // I-03: a magic item that needs attunement (one instance a piece); cursed: its bond can't be ended at will.
    public bool? RequiresAttunement { get; set; }
    public bool? Cursed { get; set; }
    // I-08: its charges (null: none);
    public ItemChargesData? Charges { get; set; }
    // I-09: what it gives and lets its holder do (ItemCapability list, the workshop's to check).
    public System.Text.Json.Nodes.JsonArray? Capabilities { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}
