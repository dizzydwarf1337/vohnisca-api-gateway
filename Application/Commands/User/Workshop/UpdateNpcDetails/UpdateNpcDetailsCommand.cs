using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.UpdateNpcDetails;

public class UpdateNpcDetailsCommand : UserRequest<bool>
{
    public Guid NpcId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string CreatureType { get; set; } = "Humanoid";
    public string Size { get; set; } = "Medium";
    public string Alignment { get; set; } = "Unaligned";
    public int ArmorClass { get; set; }
    public int MaxHitPoints { get; set; }
    public string HitDiceFormula { get; set; } = string.Empty;
    public int Speed { get; set; }
    public double ChallengeRating { get; set; }
}
