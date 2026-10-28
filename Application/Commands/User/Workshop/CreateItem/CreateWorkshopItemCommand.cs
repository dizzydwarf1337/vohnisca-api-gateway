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
    public List<Guid>? GrantedSpellIds { get; set; }
    public Dictionary<string, int>? AbilityScoreBonuses { get; set; }
    public int? ArmorClassBonus { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}
