using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.AnnounceSpell;

// The GM says an NPC begins to cast a spell (its name, the level of its slot): the characters
// who may Counterspell it are offered to.
public class AnnounceSpellCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public string SpellName { get; set; } = string.Empty;
    public int Level { get; set; }
}
