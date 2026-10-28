using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Workshop.SetNpcProfile;

// What the stat block lists beside its numbers; each list replaces the one it had.
public class SetNpcProfileCommand : UserRequest<bool>
{
    public Guid NpcId { get; set; }
    public List<string> SavingThrowProficiencies { get; set; } = new();
    public Dictionary<string, int> SkillBonuses { get; set; } = new();
    public List<string> DamageResistances { get; set; } = new();
    public List<string> DamageImmunities { get; set; } = new();
    public List<string> DamageVulnerabilities { get; set; } = new();
    public List<string> ConditionImmunities { get; set; } = new();
    public Dictionary<string, int> Senses { get; set; } = new();
    public List<string> Languages { get; set; } = new();
    public Dictionary<string, int> SpecialSpeeds { get; set; } = new();
}
