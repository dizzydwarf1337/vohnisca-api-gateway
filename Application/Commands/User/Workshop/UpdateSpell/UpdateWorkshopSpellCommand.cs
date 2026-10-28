using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.UpdateSpell;

public class UpdateWorkshopSpellCommand : UserRequest<bool>
{
    public Guid SpellId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public int Level { get; set; }
    public string School { get; set; } = "Abjuration";
    public string CastingTime { get; set; } = string.Empty;
    public string Range { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AtHigherLevels { get; set; } = string.Empty;
    public bool HasVerbalComponent { get; set; }
    public bool HasSomaticComponent { get; set; }
    public bool HasMaterialComponent { get; set; }
    public string MaterialComponents { get; set; } = string.Empty;
    public bool IsRitual { get; set; }
    public bool IsConcentration { get; set; }
    public bool RemoveImage { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}
