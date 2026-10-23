using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Session.GetSpellInfo;

// A spell's details; CharacterId: whose spell it is (how it has it, its numbers).
public class GetSpellInfoQuery : UserRequest<SpellInfoData>
{
    public Guid SessionId { get; set; }
    public Guid SpellId { get; set; }
    public Guid? CharacterId { get; set; }
}
