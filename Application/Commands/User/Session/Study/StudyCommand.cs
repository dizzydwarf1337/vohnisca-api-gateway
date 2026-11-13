using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.User.Session.Study;

// Study: an Intelligence check (Arcana, History, Investigation, Nature, Religion); Dc and an NPC's Bonus are the GM's.
public class StudyCommand : UserRequest<CombatResultData>
{
    public Guid SessionId { get; set; }
    public Guid TokenId { get; set; }
    public string Skill { get; set; } = string.Empty;
    public int? Dc { get; set; }
    public int? Bonus { get; set; }
}
