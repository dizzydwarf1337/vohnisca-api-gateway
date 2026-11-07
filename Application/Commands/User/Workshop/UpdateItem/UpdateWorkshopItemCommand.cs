using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.UpdateItem;

public class UpdateWorkshopItemCommand : UserRequest<bool>
{
    public Guid ItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public double Weight { get; set; }
    public int ValueInCopper { get; set; }
    public string Rarity { get; set; } = "Common";
    // Raw property names; when sent, the list replaces the old one as a whole.
    public List<string>? Properties { get; set; }
    public List<Guid>? GrantedSpellIds { get; set; }
    public Dictionary<string, int>? AbilityScoreBonuses { get; set; }
    public int? ArmorClassBonus { get; set; }
    public bool RemoveImage { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}
