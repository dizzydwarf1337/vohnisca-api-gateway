using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.ReadySpell;

// A spell readied: its slot spent now, held with concentration until the reaction releases it.
public class ReadySpellCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid CharacterId { get; set; }
    public Guid SpellId { get; set; }
    public int? SlotLevel { get; set; }
    public string Trigger { get; set; } = string.Empty;
}
