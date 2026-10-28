using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.CreateSpell;

// A user's own spell in the workshop service. School and Visibility by name ("Evocation",
// "Public", "FriendsOnly"); Image is the optional icon from the form's file; ids come from
// the route.
public class CreateWorkshopSpellCommand : UserRequest<CreatedContent>
{
    public string Name { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public int Level { get; set; }
    public string School { get; set; } = "Abjuration";
    public string CastingTime { get; set; } = string.Empty;
    public string Range { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Visibility { get; set; } = "Private";
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}
