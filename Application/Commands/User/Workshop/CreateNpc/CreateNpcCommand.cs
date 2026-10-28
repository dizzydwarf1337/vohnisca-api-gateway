using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.CreateNpc;

// A workshop NPC (a stat block); enums by name.
public class CreateNpcCommand : UserRequest<CreatedContent>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string CreatureType { get; set; } = "Humanoid";
    public string Size { get; set; } = "Medium";
    public string Alignment { get; set; } = "Unaligned";
    public int ArmorClass { get; set; }
    public int MaxHitPoints { get; set; }
    public double ChallengeRating { get; set; }
    public string Visibility { get; set; } = "Private";
}
